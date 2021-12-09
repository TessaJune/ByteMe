using System;
using Trainor.Storage.Entities;
using System.Collections.Generic;

namespace Trainer.Storage {
    public static class ResourceComparator
    {
        public static bool IsEqual(this ResourceDto r1, ResourceDto r2)
        {
            if(r1.name == null) return false;
            if(r2.name == null) return false;
            if(!r1.name.Equals(r2.name)) return false;
            var enumerator1 = r1.authors.GetEnumerator();
            var enumerator2 = r2.authors.GetEnumerator();
            while (enumerator1.MoveNext())
            {
                enumerator2.MoveNext();
                if (enumerator1.Current == null) return false;
                if (enumerator2.Current == null) return false;
                if(!enumerator1.Current.Equals(enumerator2.Current)) return false;
            }
            return true;
        }

        public static bool IsEqual(this ResourceDto r1, ResourceDetailsDto r2)
        {
            if(r1.name == null) return false;
            if(r2.name == null) return false;
            if(!r1.name.Equals(r2.name)) return false;
            var enumerator1 = r1.authors.GetEnumerator();
            var enumerator2 = r2.authors.GetEnumerator();
            while (enumerator1.MoveNext())
            {
                enumerator2.MoveNext();
                if (enumerator1.Current == null) return false;
                if (enumerator2.Current == null) return false;
                if(!enumerator1.Current.Equals(enumerator2.Current)) return false;
            }
            return true;
        }
        public static bool IsEqual(this ResourceDetailsDto r1, ResourceDto r2)
        {
            if(r1.name == null) return false;
            if(r2.name == null) return false;
            if(!r1.name.Equals(r2.name)) return false;
            var enumerator1 = r1.authors.GetEnumerator();
            var enumerator2 = r2.authors.GetEnumerator();
            while (enumerator1.MoveNext())
            {
                enumerator2.MoveNext();
                if (enumerator1.Current == null) return false;
                if (enumerator2.Current == null) return false;
                if(!enumerator1.Current.Equals(enumerator2.Current)) return false;
            }
            return true;
        }
        public static bool IsEqual(this ResourceDetailsDto r1, ResourceDetailsDto r2)
        {
            if(r1.name == null) return false;
            if(r2.name == null) return false;
            if(!r1.name.Equals(r2.name)) return false;
            var enumerator1 = r1.authors.GetEnumerator();
            var enumerator2 = r2.authors.GetEnumerator();
            while (enumerator1.MoveNext())
            {
                enumerator2.MoveNext();
                if (enumerator1.Current == null) return false;
                if (enumerator2.Current == null) return false;
                if(!enumerator1.Current.Equals(enumerator2.Current)) return false;
            }
            return true;
        }
    }
}
