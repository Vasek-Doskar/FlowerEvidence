using FlowerEvidence.Interfaces;
using FlowerEvidence.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerEvidence.Factory
{
    public class FlowerFactory : IFlowerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public FlowerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public AddNewFlowerWindow CreateAddWindow()
        {
            return _serviceProvider.GetRequiredService<AddNewFlowerWindow>();
        }

        public UpdateExistingFlowerWindow CreateUpdateWindow(int id)
        {
            return ActivatorUtilities.CreateInstance<UpdateExistingFlowerWindow>(_serviceProvider, id);
        }
    }
}
