namespace Shared.Vistas
{
    public class GenericResponse
    {
        public string Message { get; set; }
        public GenericResponse(string message)
        {
            Message = message;
        }
    }
}
