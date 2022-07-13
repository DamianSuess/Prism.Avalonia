﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Prism.Container.Avalonia.Tests
{
    public class ContainerExtension { }

    [CollectionDefinition(nameof(ContainerExtension), DisableParallelization = true)]
    public class ContainerExtensionCollection : ICollectionFixture<ContainerExtension>
    {
    }
}
