using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PolyStore.Test
{
    [CollectionDefinition("Repository collection")]
    public class RepositoryCollection : ICollectionFixture<RepositoryFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
