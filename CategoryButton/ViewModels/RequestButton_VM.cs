namespace CategoryButton.ViewModels
{
    public class RequestCreateCategory
    {
        public string CategoryName {  get; set; }
        public string CategoryDescription { get; set; }
    }

    public class RequestDeleteCategory
    {
        public int CategoryId { get; set; }
    }
    public class RequestUpdateCategory
    { 
        public int CategoryId { get; set; }
        public string CategoryName { get; set;}
        public string CategoryDescription { get; set;}
    }
}
