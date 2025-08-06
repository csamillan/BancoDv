using System.ComponentModel;

namespace Shared.Enum
{
    public enum TypeTransaccion : byte
    {
        [Description("Credito")] Credito = 1,
        [Description("Debito")] Debito = 2,
    }
}
