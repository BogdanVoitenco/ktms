using System;
using System.Collections.Generic;

class Heap
{
    private List<int> heap;

    public Heap()
    {
        heap = new List<int>();
    }

    public void Insert(int value)
    {
        heap.Add(value);
        HeapifyUp();
    }

    public int Delete()
    {
        if (heap.Count == 0)
        {
            throw new InvalidOperationException("Heap is empty");
        }

        int root = heap[0];
        int lastElementIndex = heap.Count - 1;

        heap[0] = heap[lastElementIndex];
        heap.RemoveAt(lastElementIndex);

        HeapifyDown();

        return root;
    }

    public int Peek()
    {
        if (heap.Count == 0)
        {
            throw new InvalidOperationException("Heap is empty");
        }

        return heap[0];
    }

    private void HeapifyUp()
    {
        int currentIndex = heap.Count - 1;

        while (currentIndex > 0)
        {
            int parentIndex = (currentIndex - 1) / 2;

            if (heap[currentIndex] > heap[parentIndex])
            {
                Swap(currentIndex, parentIndex);
                currentIndex = parentIndex;
            }
            else
            {
                break;
            }
        }
    }

    private void HeapifyDown()
    {
        int currentIndex = 0;
        int leftChildIndex;
        int rightChildIndex;
        int maxIndex;

        while (true)
        {
            leftChildIndex = 2 * currentIndex + 1;
            rightChildIndex = 2 * currentIndex + 2;
            maxIndex = currentIndex;

            if (leftChildIndex < heap.Count && heap[leftChildIndex] > heap[maxIndex])
            {
                maxIndex = leftChildIndex;
            }

            if (rightChildIndex < heap.Count && heap[rightChildIndex] > heap[maxIndex])
            {
                maxIndex = rightChildIndex;
            }

            if (maxIndex != currentIndex)
            {
                Swap(currentIndex, maxIndex);
                currentIndex = maxIndex;
            }
            else
            {
                break;
            }
        }
    }

    private void Swap(int index1, int index2)
    {
        int temp = heap[index1];
        heap[index1] = heap[index2];
        heap[index2] = temp;
    }
}

class Heapy
{
    static void Main()
    {
        Heap maxHeap = new Heap();

        maxHeap.Insert(10);
        maxHeap.Insert(20);
        maxHeap.Insert(15);

        Console.WriteLine("Peek: " + maxHeap.Peek()); // 20

        maxHeap.Insert(5);
        maxHeap.Insert(25);

        Console.WriteLine("Peek after insertions: " + maxHeap.Peek()); // 25

        Console.WriteLine("Deleted: " + maxHeap.Delete()); // 25

        Console.WriteLine("Peek after deletion: " + maxHeap.Peek()); // 20
    }
}
