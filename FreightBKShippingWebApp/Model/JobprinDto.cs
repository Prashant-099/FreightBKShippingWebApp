namespace FreightBKShippingWebApp.Model
{
    public class JobreportDto
    {
        public int JobId { get; set; }
        public int? JobCompanyId { get; set; }
        public string? JobAddedByUserId { get; set; }
        public string? JobUpdatedByUserId { get; set; }
        public int? JobPartyId { get; set; }
        public string? JobYearId { get; set; }
        public DateTime? JobDate { get; set; }
        public string? JobNo { get; set; }
        public string? JobType { get; set; }
        public int? JobPodId { get; set; }
        public int? JobPolId { get; set; }
        public int? JobVesselId { get; set; }
        public int? JobLineId { get; set; }
        public int? JobCargoId { get; set; }
        public int? JobConsigneeId { get; set; }
        public int? JobShipperId { get; set; }
        public int? JobSalesmanId { get; set; }
        public string? JobSbNo { get; set; }
        public DateTime? JobSbDate { get; set; }
        public string? JobBlNo { get; set; }
        public DateTime? JobBlDate { get; set; }
        public string? JobShipperInvNo { get; set; }
        public DateTime? JobShipperInvDate { get; set; }
        public double? JobGrossWt { get; set; }
        public double? JobNetWt { get; set; }
        public double? JobQty { get; set; }
        public double? JobExchRate { get; set; }
        public string? Job20Ft { get; set; }
        public string? Job40Ft { get; set; }
        public string? JobContainer20Ft { get; set; }
        public string? JobContainer40Ft { get; set; }
        public int? JobDefCurrId { get; set; }
        public string? JobRemarks { get; set; }
        public int? JobVchNo { get; set; }
        public string? JobPrefix { get; set; }
        public string? JobSufix { get; set; }
        public bool? JobActive { get; set; }
        public int? JobTypeId { get; set; }
        public string? JobCust1 { get; set; }
        public string? JobCust2 { get; set; }
        public string? JobCust3 { get; set; }
        public string? JobCust4 { get; set; }
        public string? JobCust5 { get; set; }
        public string? JobCust6 { get; set; }
        public string? JobCust7 { get; set; }
        public string? JobCust8 { get; set; }
        public string? JobCust9 { get; set; }
        public string? JobGoodsDesc { get; set; }


        public int? JobChaId { get; set; }
        public string? JobBeNo { get; set; }
        public DateTime? JobBeDate { get; set; }
        public int? JobSupplierId { get; set; }
        public float? JobDoPer { get; set; }
        public DateTime? JobDoDate { get; set; }
        public string? JobDoNo { get; set; }
        public int? JobApprovedBy { get; set; }
        public string? JobForwarder { get; set; }
        public string? JobBookingNo { get; set; }
        public string? JobHsnCode { get; set; }
        public string? JobHblNo { get; set; }
        public string? JobBrand { get; set; }
        public string? JobSealNo { get; set; }
        public string? JobAgent { get; set; }
        public string? JobPartyAddress { get; set; }
        public string? JobHighseas1Address { get; set; }
        public DateTime? JobDoValid { get; set; }

        // ✅ Joined / UI fields
        public string? VesselName { get; set; }
        public string? PolName { get; set; }
        public string? PodName { get; set; }
        public string? BranchName { get; set; }
        public string? Partyname { get; set; }
        public string? Consigneename { get; set; }
        public string? Linename { get; set; }

        //-------------------------------------
        public string? JobSubType { get; set; }

        public bool? IsTransportaion { get; set; }
        public bool? IsClearing { get; set; }

        public bool? IsForwarding { get; set; }
        public bool? IsMiscService { get; set; }
        public string? JobShipmentType { get; set; }

        public List<Lr> lrs { get; set; } = new List<Lr>();
        public Company? Company { get; set; }


    }
}
