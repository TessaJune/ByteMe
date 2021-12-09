using System;
using Trainor.Storage.Entities;

namespace Trainer.Storage {
    public static class ResourceComparator
    {
        public static bool IsEqual(this ResourceDto r1, ResourceDto r2)
        {
            if(r1.name != r2.name) return false;
            if(r1.authors != r2.authors) return false;
            return true;
        }

        public static bool IsEqual(this ResourceDto r1, ResourceDetailsDto r2)
        {
            if(r1.name != r2.name) return false;
            if(r1.authors != r2.authors) return false;
            return true;
        }
        public static bool IsEqual(this ResourceDetailsDto r1, ResourceDto r2)
        {
            if(r1.name != r2.name) return false;
            if(r1.authors != r2.authors) return false;
            return true;
        }
        public static bool IsEqual(this ResourceDetailsDto r1, ResourceDetailsDto r2)
        {
            if(r1.name != r2.name) return false;
            if(r1.authors != r2.authors) return false;
            return true;
        }
    }
}
