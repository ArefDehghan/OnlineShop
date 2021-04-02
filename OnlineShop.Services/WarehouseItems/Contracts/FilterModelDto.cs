namespace OnlineShop.Services.WarehouseItems.Contracts
{
    public class FilterModelDto
    {
        public FilterModelDto()  
        {  
            this.Page = 1;  
            this.Limit = 3;  
            this.IsAscending = true;
        }  
        public int Page { get; set; }        
        public int Limit { get; set; }  
        public string Term { get; set; }
        public bool IsAscending { get; set; }
    }
}