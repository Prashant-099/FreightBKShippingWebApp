using FreightBKShippingWebApp.Model;
using System.Net.Http;

namespace FreightBKShippingWebApp.Services
{
    public class StateService
    {
        private readonly ApiClient _apiClient;

        public StateService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        // Get all states
        public async Task<List<State>?> GetStatesAsync()
        {
            return await _apiClient.GetFromJsonAsync<List<State>>("/api/states");
        }

        // Get state by Id
        public async Task<State?> GetStateByIdAsync(int id)
        {
            return await _apiClient.SafeGetFromJsonAsync<State>($"/api/states/{id}");
        }

        /// <summary>
        /// Get state by Name
        /// </summary>
        /// <param name="stateName"></param>
        /// <returns></returns>
        /// <summary>
        /// Gets state ID by name, or creates new state if not found
        /// </summary>
        public async Task<int> GetOrCreateStateIdAsync(string stateName, string? stateCode = null)
        {
            if (string.IsNullOrWhiteSpace(stateName))
                throw new ArgumentException("State name cannot be empty", nameof(stateName));

            try
            {
                var request = new State
                {
                    StateName = stateName.Trim(),
                    StateCode = stateCode?.Trim()
                };

                var result = await _apiClient.PostAsync<State, State>(
                    "api/States/",
                    request
                );

                if (result?.StateId == null)
                    throw new Exception("Invalid response from API");

                return result.StateId;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get or create state: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Gets state by name only (returns null if not found)
        /// </summary>
        public async Task<State?> GetStateByCodeAsync(string stateCode)
        {
            if (string.IsNullOrWhiteSpace(stateCode))
                return null;

            try
            {
                return await _apiClient.GetFromJsonAsync<State>(
                    $"api/States/GetByCode/{Uri.EscapeDataString(stateCode)}"
                );
            }
            catch
            {
                return null;
            }
        }


        // Create new state
        public async Task<State?> CreateStateAsync(State state)
        {
            return await _apiClient.PostAsync<State, State>("/api/states", state);
        }

        // Update state
        public async Task<State?> UpdateStateAsync(int id, State state)
        {
            return await _apiClient.PutAsync<State, State>($"/api/states/{id}", state);
        }

        // Delete state
        public async Task<bool> DeleteStateAsync(int id)
        {
            var result = await _apiClient.DeleteAsync<bool>($"/api/states/{id}");
            return result;
        }
    }
}
