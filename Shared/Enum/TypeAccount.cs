using System.ComponentModel;

namespace Shared.Enum
{
    public enum TypeAccount : Byte
    {
        [Description("Ahorros")] Ahorros = 1,
        [Description("Corriente")] Corriente = 2,
    }
}
