using Object = System.Object;
using IndexOutOfRangeException = System.IndexOutOfRangeException;
using Int32 = System.Int32;
using Console = System.Console;
using Math = System.Math;
using GC = System.GC;
using Array = System.Array;

namespace myList {
    class myList<T> {
        int num;
        int maxSize;
        T[] list;
        public int Length { get { return this.num; } }
        public T this[int index] {
            get {
                return list[index];
            }

            set {
                try {
                    list[index] = value;
                }
                catch (IndexOutOfRangeException e) {
                    Console.WriteLine(e);
                }
            }
        }

        public myList(int maxSize) {
            num = 0;
            this.maxSize = maxSize;
            list = new T[maxSize];
        }

        public myList() : this(8) {
        }

        public myList(myList<T> copyBy) {
            for (int i = 0; i < copyBy.Length; ++i)
                this.list[i] = copyBy[i];
        }

        //if maxSize is too small,let it big
        private void makeBig(int number) {
            T[] temp = new T[number];
            for (int i = 0; i < this.Length; ++i)
                temp[i] = this.list[i];
            this.list = temp;
            GC.Collect();
            maxSize = number;
        }

        //implement Add()
        public void add(T target) {
            if (num < maxSize)
                list[num++] = target;
            else {
                makeBig(maxSize * 2);
                list[num++] = target;
            }
        }

        //implement Clear()
        public void clear() {
            num = 0;
            maxSize = 8;
            list = new T[maxSize];
        }

        //implement copyTo
        public void copyTo(myList<T> target) {
            this.copyTo(target, 0);
        }

        public void copyTo(myList<T> target, Int32 index) {
            this.copyTo(target, index, this.num);
        }

        public void copyTo(myList<T> target, Int32 begin, Int32 end) {
            try {
                for (int i = begin; i < end; ++i)
                    target.add(this[i]);
            }
            catch (IndexOutOfRangeException e) {
                Console.WriteLine(e);
            }
        }

        //implement Equal()
        public override bool Equals(Object obj) {
            if (obj.GetType() != this.GetType() || obj == null)
                return false;
            else {
                myList<T> temp = obj as myList<T>;
                for (int i = 0; i < Math.Max(temp.Length, this.Length); ++i)
                    if (!temp.list[i].Equals(this.list[i]))
                        return false;
            }
            return true;
        }

        //implement IndexOf()
        public int indexOf(T target) {
            return this.indexOf(target, 0);
        }

        public int indexOf(T target,Int32 begin) {
            return this.indexOf(target, begin, this.num);
        }

        public int indexOf(T target,Int32 begin,Int32 end) {
            for (int i = begin; i < end; ++i)
                if (target.Equals(this[i]))
                    return i+1;
            return -1;
        }

        //implement Remove()
        public void remove(T target) {
            this.removeAt(indexOf(target)-1);
        }

        //implement RemoveAll()
        public void removeAll(T target) {
            int temp;
            while((temp = indexOf(target)) != -1) {
                removeAt(temp);
            }
        }

        //implement RemoveAt()
        public void removeAt(int index) {
            this.removeAt(index, 1);
        }

        public void removeAt(int index, int offest) {
            for (int i = index; i < num - offest; ++i)
                this[i] = this[i + offest];
            this.num -= offest;
        }

        //implement Sort() by using quick sort,
        public void sort() {
            Array.Sort(list);
        }

        //private void quickSort(ref T[] target,int left,int right) {
        //    int pivot = (left + right) / 2;
        //    int i = left;
        //    int j = right;

        //    while (left<right) {
        //        //if(target[i])
        //    }

        //    quickSort(ref target, left, pivot - 1);
        //    quickSort(ref target, pivot, right);
        //}

        //private void swap(ref T target1,ref T target2) {
        //    var temp = target2;
        //    target2 = target1;
        //    target1 = temp;
        //    GC.Collect();
        //}
    }
}
