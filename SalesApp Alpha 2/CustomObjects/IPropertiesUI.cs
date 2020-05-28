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
    public interface IPropertiesUI<T> where T : CObjectCRUD
    {
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
        /// Arroja un error en la interfaz de usuario en la propiedad correspondiente
        /// según la excepción proveida
        /// </summary>
        /// <param name="exception">Excepción a analizar</param>
        /// <exception cref="InvalidCastException"></exception>
        void ExceptionsHandler(Exception exception);

        /// <summary>
        /// Arroja una serie de errores en la interfaz de usuario en las propiedades
        /// correspondientes según la excepciones proveidas
        /// </summary>
        /// <param name="exceptions">Lista de excepciones</param>
        /// <exception cref="InvalidCastException">Excepción no valida</exception>
        void ExceptionsHandler(List<Exception> exceptions);

        /// <summary>
        /// Valida el objeto obteniendo las excepciones
        /// de <see cref="CObjectCRUD.GetListExceptions"/> y manejandolas por el método
        /// <see cref="ExceptionsHandler(List{Exception})"/> si existen excepciones debe
        /// arrojar otra excepción para interrumpir el proceso.
        /// </summary>
        void ValidateObject();
    }
}