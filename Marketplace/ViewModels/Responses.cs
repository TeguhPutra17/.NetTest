namespace CategoryLoadData.ViewModels
{
    public class ServiceResponses<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; }
    }
}
