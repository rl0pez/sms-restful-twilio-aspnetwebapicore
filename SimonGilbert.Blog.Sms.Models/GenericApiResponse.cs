namespace SimonGilbert.Blog.Sms.Models
{
    public class GenericApiResponse
    {
        public GenericApiResponse(object response)
        {
            this.Response = response;
        }

        public object Response { get; private set; }
    }
}