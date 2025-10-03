using FreightBKShippingWebApp.Model;

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
            return await _apiClient.SafeGetFromJsonAsync<List<State>>("/api/states");
        }

        // Get state by Id
        public async Task<State?> GetStateByIdAsync(int id)
        {
            return await _apiClient.SafeGetFromJsonAsync<State>($"/api/states/{id}");
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
