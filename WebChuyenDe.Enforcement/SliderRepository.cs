using WebChuyenDe.Data;
using WebChuyenDen.Interface;

namespace WebChuyenDe.Enforcement
{
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        public SliderRepository(IDbFactory shoppingCartEntities)
           : base(shoppingCartEntities) { }
    }
}