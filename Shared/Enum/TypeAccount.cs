using System.ComponentModel;

namespace Shared.Enum
{
    public enum TypeAccount : Byte
    {
        [Description("Ahorros")] Saving = 1,
        [Description("Corriente")] Running = 2,
    }
}
