namespace SalesApp_Alpha_2
{
    public interface INegotiable
    {
        /// <summary>
        /// Se lanza al comprar un objeto
        /// </summary>
        event CrudEventHandler Purchased;
        /// <summary>
        /// Se lanza al vender un objeto
        /// </summary>
        event CrudEventHandler Selled;
        /// <summary>
        /// Procesa la compra de un objeto
        /// </summary>
        /// <param name="quantity">Cantidad de elementos</param>
        void Purchase(int quantity);
        /// <summary>
        /// Procesa la venta de un objeto
        /// </summary>
        /// <param name="quantity">Cantidad de elementos</param>
        void Sell(int quantity);
    }
}
