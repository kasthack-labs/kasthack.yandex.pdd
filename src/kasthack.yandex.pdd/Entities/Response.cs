namespace kasthack.yandex.pdd.Entities
{

    public class Response
    {
        public string Domain { get; set; }
        public bool Success { get; set; }
        public ErrorCode Error { get; set; }
    }
}