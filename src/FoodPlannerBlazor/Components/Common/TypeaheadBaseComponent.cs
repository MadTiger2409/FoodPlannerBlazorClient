using FoodPlannerBlazor.Domain.Entities.Common;
using FoodPlannerBlazor.ViewModels.Common;
using System.Collections.Generic;
using System.Linq;

namespace FoodPlannerBlazor.Components.Common
{
    public class TypeaheadBaseComponent<TViewModel> : BaseComponent<TViewModel> where TViewModel : BaseViewModel
    {
        protected static int? ConvertEntityToId<TEntity>(TEntity entity) where TEntity : BaseEntity => entity.Id;

        protected static TEntity LoadSelectedEntity<TEntity>(int? id, List<TEntity> entities) where TEntity : BaseEntity
            => entities.FirstOrDefault(x => x.Id == id);
    }
}
