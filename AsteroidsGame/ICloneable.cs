using System;

namespace AsteroidsGame
{
    interface ICloneable
    {
        /// <summary>
        ///   Создает новый объект, являющийся копией текущего экземпляра.
        /// </summary>
        /// <returns>Новый объект, являющийся копией этого экземпляра.</returns>
        object Clone();
    }
}
