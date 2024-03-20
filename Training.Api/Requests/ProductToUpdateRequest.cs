namespace Training.Api;

public record ProductToUpdateRequest(int Id, string Descripcion, string CodigoProducto, decimal Precio);