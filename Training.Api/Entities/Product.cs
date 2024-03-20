namespace Training.Api;

public record class Product : Entity
{
    public string Descripcion { get; private set; } = string.Empty;

    public string CodigoProducto { get; private set; } = string.Empty;

    public decimal Precio { get; private set; }

    public static Product CreateNew(string Descripcion, string CodigoProducto, decimal Precio)
        =>  new()
        {
            Descripcion = Descripcion,
            CodigoProducto = CodigoProducto,
            Precio = Precio
        };
}
/*
   [Id]				INT PRIMARY KEY IDENTITY(1,1),
   [Descripcion]	NVARCHAR(50) NOT NULL,
   [CodigoProducto] NVARCHAR(50) NOT NULL,
   [Precio]			DECIMAL(5,2) NOT NULL,
)
*/
