using System;
using System.Collections.Generic;

namespace SalesApp_Alpha_2
{
    /// <summary>
    /// Métodos para manejo de una interfaz de usuario que controla propiedades
    /// de un objeto heredado de <see cref="CObjectCRUD"/>
    /// </summary>
    /// <typeparam name="T">Tipo de objeto que manejará 
    /// la interfaz de usuario</typeparam>
    public interface IPropertiesUI<T> where T : ICrud
    {
        ///// <summary>
        ///// Expone si el objeto está validado
        ///// </summary>
        //bool IsValid { get; }

        /// <summary>
        /// Recopila los valores de las propiedades en la
        /// interfaz de usuario y las empaqueta en su respectivo objeto
        /// </summary>
        /// <returns><see cref="CObjectCRUD"/> que modifica el control</returns>
        T GetObject();

        /// <summary>
        /// Carga los valores de las propiedades del objeto en la interfaz de usuario
        /// </summary>
        /// <param name="value">Objeto a cargar</param>
        void SetObject(T value);

        /// <summary>
        /// Desactiva los errores de propiedades en la interfaz de usuario
        /// </summary>
        void DisableVisualErrors();

        /// <summary>
        /// Retorna los valores predeterminados de las propiedadades en la
        /// interfaz de usuario
        /// </summary>
        void ClearProperties();

        /// <summary>
        /// Establece como activo este cuadro de propiedades
        /// </summary>
        void SetFocus();

        /// <summary>
        /// Valida el objeto obteniendo las excepciones
        /// de <see cref="CObjectCRUD.GetListExceptions"/> y manejandolas por el método
        /// <see cref="ExceptionsHandler(List{Exception})"/> si existen excepciones debe
        /// arrojar otra excepción para interrumpir el proceso.
        /// </summary>
        void ValidateObject();
    }
}