using System;

namespace SalesApp_Alpha_2
{

    [Serializable]
    public class ProductException : Exception
    {
        public Product.TableFields ExceptionField { get; private set; }

        public ProductException() : base("Producto Inválido") { }
        public ProductException(Product.TableFields Field, string message) : base (message)
        {
            ExceptionField = Field;
        }

        protected ProductException(string message, Exception inner) : base(message, inner) { }
        protected ProductException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class ProductObligatoryFieldException : ProductException
    {
        public ProductObligatoryFieldException(Product.TableFields Field) : base(Field, "Este es un campo obligatorio") { }
    }

    [Serializable]
    public class ProductInvalidPriceException : ProductException
    {
        public ProductInvalidPriceException() : base(Product.TableFields.Price, "Precio inválido") { }
    }

    [Serializable]
    public class ProductSoldOutException : ProductException
    {
        public ProductSoldOutException() : base(Product.TableFields.Quantity, "Producto agotado") { }
    }



    [Serializable]
    public class ProductInvalidException : Exception
    {
        public ProductInvalidException() : base("Producto Inválido") { }
        public ProductInvalidException(string message) : base(message) { }
        public ProductInvalidException(string message, Exception inner) : base(message, inner) { }
        protected ProductInvalidException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class ProductWorthlessException : Exception
    {
        public ProductWorthlessException() : base("No se puede configurar el precio en Cero") { }
        public ProductWorthlessException(string message) : base(message) { }
        public ProductWorthlessException(string message, Exception inner) : base(message, inner) { }
        protected ProductWorthlessException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class ProductNoQuantityException : Exception
    {
        public ProductNoQuantityException() : base("No se pueden añadir Cero productos") { }
        public ProductNoQuantityException(string message) : base(message) { }
        public ProductNoQuantityException(string message, Exception inner) : base(message, inner) { }
        protected ProductNoQuantityException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class ProductCriticalValuesException : Exception
    {   
        public ProductCriticalValuesException() : base("Datos de producto requeridos"){ }
        public ProductCriticalValuesException(string message) : base(message) { }
        public ProductCriticalValuesException(string message, Exception inner) : base(message, inner) { }
        
        protected ProductCriticalValuesException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
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