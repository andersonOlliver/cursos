namespace XGame.Domain.Arguments
{
    public class ResponseBase
    {

        public ResponseBase()
        {
            Message = Properties.Message.OPERACAO_REALIZADA_COM_SUCESSO;
        }

        public ResponseBase(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
