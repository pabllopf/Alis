using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public static class GameObjectRules
    {
        public static readonly Predicate<GameObject>[] Validatios = 
        {
            (gameobject) => Validation<string>.NotNull(gameobject.Name),
            (gameobject) => Validation<Transform>.NotNull(gameobject.Transform)
        }; 
    }
}