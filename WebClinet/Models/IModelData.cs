using System.Threading.Tasks;

namespace WebClinet.Models
{
    public interface IModelData
    {
       Task<ModelDatas> GetModelDatasAsync();

    }
}