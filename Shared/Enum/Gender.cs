using System.ComponentModel;

namespace Shared.Enum
{
    public enum Gender : byte
    {
        [Description("Masculino")] Male = 1,
        [Description("Femenino")] Female = 2,
        [Description("Otros")] Others = 3,
    }
}
