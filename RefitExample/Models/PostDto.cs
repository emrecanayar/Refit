namespace RefitExample.Models
{
    //İstek yapacağımız end-pointten geriye dönecek olan modeli tutacak olan classımız
    public class PostDto
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
