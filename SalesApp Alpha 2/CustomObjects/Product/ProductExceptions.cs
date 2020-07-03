using System;

namespace SalesApp_Alpha_2
{

    [Serializable]
    public class ProductException : Exception
    {
        public Product.TableFields ExceptionField { get; private set; }
        private const string ExceptionMessage = "Producto inválido, sus propiedades no son aplicables";

        public ProductException() : base(ExceptionMessage) { }
        public ProductException(Product.TableFields Field, string message) : base (message)
        {
            ExceptionField = Field;
        }

        public ProductException(Exception inner) : base(ExceptionMessage, inner) { }
        protected ProductException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class ProductObligatoryFieldException : ProductException
    {
        private const string ExceptionMessage = "El campo es obligatorio, no puede estar vacío";
        public ProductObligatoryFieldException(Product.TableFields Field) : base(Field, ExceptionMessage) { }
    }

    [Serializable]
    public class ProductInvalidPriceException : ProductException
    {
        private const string ExceptionMessage = "No se puede establecer este precio";
        public ProductInvalidPriceException() : base(Product.TableFields.Price, ExceptionMessage) { }
    }

    [Serializable]
    public class ProductQuantityException : ProductException
    {
        public ProductQuantityException() : base(Product.TableFields.Quantity, "Producto agotado") { }
    }



    //[Serializable]
    //public class ProductInvalidException : Exception
    //{
    //    public ProductInvalidException() : base("Producto Inválido") { }
    //    public ProductInvalidException(string message) : base(message) { }
    //    public ProductInvalidException(string message, Exception inner) : base(message, inner) { }
    //    protected ProductInvalidException(
    //      System.Runtime.Serialization.SerializationInfo info,
    //      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    //}

    //[Serializable]
    //public class ProductWorthlessException : Exception
    //{
    //    public ProductWorthlessException() : base("No se puede configurar el precio en Cero") { }
    //    public ProductWorthlessException(string message) : base(message) { }
    //    public ProductWorthlessException(string message, Exception inner) : base(message, inner) { }
    //    protected ProductWorthlessException(
    //      System.Runtime.Serialization.SerializationInfo info,
    //      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    //}

    //[Serializable]
    //public class ProductNoQuantityException : Exception
    //{
    //    public ProductNoQuantityException() : base("No se pueden añadir Cero productos") { }
    //    public ProductNoQuantityException(string message) : base(message) { }
    //    public ProductNoQuantityException(string message, Exception inner) : base(message, inner) { }
    //    protected ProductNoQuantityException(
    //      System.Runtime.Serialization.SerializationInfo info,
    //      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    //}

    //[Serializable]
    //public class ProductCriticalValuesException : Exception
    //{   
    //    public ProductCriticalValuesException() : base("Datos de producto requeridos"){ }
    //    public ProductCriticalValuesException(string message) : base(message) { }
    //    public ProductCriticalValuesException(string message, Exception inner) : base(message, inner) { }

    //    protected ProductCriticalValuesException(
    //      System.Runtime.Serialization.SerializationInfo info,
    //      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    //}

    //[Serializable]
    public class ProductRepeatedException : Exception
    {
        public ProductRepeatedException() : base("Producto repetido") { }
        public ProductRepeatedException(string message) : base(message) { }
        public ProductRepeatedException(string message, Exception inner) : base(message, inner) { }
        protected ProductRepeatedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}