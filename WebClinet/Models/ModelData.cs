using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebChuyenDen.Interface;

namespace WebClinet.Models
{
    public class ModelData : IModelData
    {
        private readonly IProductService _productService;
        public ModelData(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<ModelDatas> GetModelDatasAsync()
        {
            ModelDatas modelDatas = new ModelDatas();
            modelDatas.ProductVms = await _productService.Getall().ToListAsync();
            return modelDatas;
        }
    }
}