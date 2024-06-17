using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace project3
{
    internal class Program
    {
        public class MilliPark //Milli park sınıfı
        {
            public string MilliPark_Adı;
            public string İl_Adları;
            public string İlan_Yılı;
            public double Yüzölçümü;
            public List<string> cumle;

            public MilliPark()
            {
                MilliPark_Adı = null;
                İl_Adları = null;
                İlan_Yılı = null;
                Yüzölçümü = 0;


            }
            public MilliPark(string milliPark_Adı, string il_Adları, string ilan_Yılı, double yüzölçümü, List<string> cumle)
            {

                MilliPark_Adı = milliPark_Adı;
                İl_Adları = il_Adları;
                İlan_Yılı = ilan_Yılı;
                Yüzölçümü = yüzölçümü;
                this.cumle = cumle; 
            }
            public override string ToString()
            {
                Console.WriteLine("(" + "Park adı:" + MilliPark_Adı + "/ İl adları :" + İl_Adları + "/ İlan tarihi:" + İlan_Yılı + "/ Yüzölçümü:" + Yüzölçümü + "/ Cümleler: " + ")");
                foreach (string i in cumle) { Console.WriteLine(i); }
                return null;
            }
        }
        class TreeNode
        {
            public MilliPark data;
            public TreeNode leftChild;
            public TreeNode rightChild;
            public void displayNode() { Console.WriteLine(" " + data + " "); }
        }

        class Tree
        {
            private TreeNode root;
            public int sayi;
            public int düzey;
            public int düzey1;
            public int dugumsayi;
            public int sayi1=1;
            public int sayi2=1;
            public int us=0;
            public Tree() { root = null; }

            public TreeNode getRoot()
            { return root; }


            public void insert(MilliPark newdata)
            {
                TreeNode newNode = new TreeNode();
                newNode.data = newdata;
                if (root == null)
                    root = newNode;
                else
                {
                    TreeNode current = root;
                    TreeNode parent;
                    while (true)
                    {
                        parent = current;
                        if (String.Compare(newdata.MilliPark_Adı, current.data.MilliPark_Adı)==1 )
                        {
                            current = current.leftChild;
                            if (current == null)
                            {
                                parent.leftChild = newNode;
                                return;
                            }
                        }
                        else
                        {
                            current = current.rightChild;
                            if (current == null)
                            {
                                parent.rightChild = newNode;
                                return;
                            }
                        }
                    } 
                } 
            } 



            public string ilbulma(  string aranan)
            {
                TreeNode etkin = root;
                while (etkin.data.MilliPark_Adı.Substring(0, 3) != aranan)
                {
                    if (String.Compare(aranan, etkin.data.MilliPark_Adı.Substring(0, 3)) == 1)
                    {
                        etkin = etkin.leftChild;
                    }
                        
                    else
                    {
                        etkin = etkin.rightChild;
                    }
                     
                    if (etkin == null) return null;

                }
                return etkin.data.İl_Adları;

            }

            public int calcMaxDepth(TreeNode node, int depthCounter,Tree2 agac2 )
            {
                
                if (node == null) return depthCounter;
                node.displayNode();
                dugumsayi++;

                if (sayi2 < 48)  
                {
                    
                    sayi1 = sayi1 * 2;
                    sayi2 += sayi1;
                    us += 1;

                }

                for (int i =0; i < node.data.cumle.Count; i++)
                {
                    string[] kelimeler = node.data.cumle[i].Split(new string[] { " " }, StringSplitOptions.None);
                    for (int j = 0; j < kelimeler.Length; j++)
                    {
                        agac2.insert(kelimeler[j]);
                    }
                }
                if (node.leftChild == null && node.rightChild == null) return depthCounter + 1;
                
                düzey = this.calcMaxDepth(node.leftChild, depthCounter + 1,  agac2);
                düzey1 = this.calcMaxDepth(node.rightChild, depthCounter + 1, agac2);

                return Math.Max(düzey, düzey1);
            }
        }
        class TreeNode2
        {
            public int tekrar=0;
            public string kelime;
            public TreeNode2 leftChild;
            public TreeNode2 rightChild;
            public void displayNode() { Console.WriteLine(" "+"Kelime:(" + kelime + ") "+"Tekrar Sayısı: ("+tekrar +") "); }
        }

        class Tree2
        {
            private TreeNode2 root;
            public int sayi;
            public int düzey;
            public int düzey1;
            
            public Tree2() { root = null; }

            public TreeNode2 getRoot()
            { return root; }

            public void insert(string newdata)
            {
                TreeNode2 newNode = new TreeNode2();
                newNode.kelime = newdata;
                if (root == null)
                {
                    root = newNode;
                    root.tekrar += 1;
                }

                else
                {
                    TreeNode2 current = root;
                    TreeNode2 parent;
                    while (true)
                    {
                        parent = current;
                        if (String.Compare(newdata, current.kelime) == 1)
                        {
                            current = current.leftChild;
                            if (current == null)
                            {
                                parent.leftChild = newNode;
                                parent.leftChild.tekrar += 1;
                                return;
                            }
                        }
                        else if (String.Compare(newdata, current.kelime) == 0)
                        {
                            parent.tekrar += 1;
                            return;
                        }
                        else
                        {
                            current = current.rightChild;
                            if (current == null)
                            {
                                parent.rightChild = newNode;
                                parent.rightChild.tekrar += 1;
                                return;
                            }
                        }
                    }
                }
            }
            public void preOrder(TreeNode2 localRoot)
            {
                if (localRoot != null)
                {
                    localRoot.displayNode();
                    preOrder(localRoot.leftChild);
                    preOrder(localRoot.rightChild);
                }
            }
        }
        class Node
        {
            public MilliPark data;

            public Node (MilliPark data)
            {
                this.data = data;
            }

            public void displayNode() { Console.WriteLine(" " + data + " "); }
        }
        class Heap
        {
            public Node[] heapArray;
            public int maxSize;
            public int currentSize;

            public Heap (int mx)
            {
                maxSize = mx;
                currentSize = 0;
                heapArray = new Node[mx];
            }
            public Boolean isEmpty() { return currentSize == 0; }

            public Boolean insert(MilliPark key)
            {
                if (currentSize == maxSize)
                    return false;
                Node newNode = new Node(key);
                heapArray[currentSize] = newNode;
                trickleUp(currentSize++);
                return true;
            } 

            public void trickleUp(int index)
            {
                int parent = (index - 1) / 2;
                Node bottom = heapArray[index];
                while (index > 0 && heapArray[parent].data.Yüzölçümü < bottom.data.Yüzölçümü)
                {
                    heapArray[index] = heapArray[parent]; 
                    index = parent;
                    parent = (parent - 1) / 2;
                } 
                heapArray[index] = bottom;
            } 
            public MilliPark remove() 
            { 
                Node root = heapArray[0];
                heapArray[0] = heapArray[--currentSize];
                trickleDown(0);
                return root.data;
            } 

            public void trickleDown(int index)
            {
                int largerChild;
                Node top = heapArray[index]; 
                while (index < currentSize / 2) 
                { 
                    int leftChild = 2 * index + 1;
                    int rightChild = leftChild + 1;
                  
                    if (rightChild < currentSize && 
                    heapArray[leftChild].data.Yüzölçümü <
                    heapArray[rightChild].data.Yüzölçümü)
                        largerChild = rightChild;
                    else
                        largerChild = leftChild;
                    
                    if (top.data.Yüzölçümü >= heapArray[largerChild].data.Yüzölçümü)
                        break;
                   
                    heapArray[index] = heapArray[largerChild];
                    index = largerChild;
                }
                heapArray[index] = top;
            }
            public void listele()
            {
                Console.WriteLine(heapArray[0].data);
                Console.WriteLine(heapArray[1].data);
                Console.WriteLine(heapArray[2].data);

            }

        }
        class SelectionSort
        {
            public void swap(int[] arr,int i, int j)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                
            }
            public void sort(int[] arr)
            {
                
                int n = arr.Length;

                for (int i = 0; i < n; i++)
                {
                    int minIndex = i;
                    for (int j = i + 1; j < n; j++)
                    {
                        if (arr[j] < arr[minIndex])
                        {
                            minIndex = j;
                        }
                    }
                    
                    swap(arr, minIndex, i);
                }
                
            }
        }

            static void Main(string[] args)
        {
            string[,] liste = new string[48, 4];
            string[] milliparkadları = new string[48];
            string[] şehirler = new string[48];
            string[] yuzolcumler1 = new string[48];
            double[] yuzolcumler = new double[48];
            string[] ilanyıllari = new string[48];
            
            List<List<string>> paragraflar = new List<List<string>> ();


            string[] data1 = System.IO.File.ReadAllLines(@"paragraphs.txt");
            for (int i = 0; i < data1.Length; i++)
            {
                string veri = data1[i];
                string[] cumleler = veri.Split(new string[] { ". " }, StringSplitOptions.None);
                
                List<string> paragraf = new List<string>();
                for (int j = 0; j < cumleler.Length; j++)
                {
                    paragraf.Add(cumleler[j]);
                   
                }
                paragraflar.Add(paragraf);
                

            }

            string[] data = System.IO.File.ReadAllLines(@"nationalPark.txt");
            for (int i = 0; i < data.Length; i++)
            {
                string veri = data[i];
                string[] sozcukler = veri.Split(',');
                for (int j = 0; j < 4; j++)
                {

                    liste[i, j] = (sozcukler[j]);
                }
            }

            for (int i = 0; i < 48; i++) 
            {

                milliparkadları[i] = liste[i, 0];
                şehirler[i] = liste[i, 1];
                yuzolcumler1[i] = liste[i, 2];
                ilanyıllari[i] = liste[i, 3];


            }
            for (int i = 0; i < 48; i++) 
            {
                yuzolcumler[i] = double.Parse(yuzolcumler1[i]);
            }
            MilliPark millipark;
            Tree agac = new Tree();
            Hashtable hash = new Hashtable();
            Heap heap = new Heap(48);
            for (int i = 0; i < 48; i++)
            {
                millipark = new MilliPark(milliparkadları[i], şehirler[i], ilanyıllari[i], yuzolcumler[i], paragraflar[i]);
                agac.insert(millipark);
                hash.Add(milliparkadları[i],millipark);
                heap.insert(millipark);
                
            }

            Tree2 agac2 = new Tree2();
            int derinlik= agac.calcMaxDepth(agac.getRoot(),0,agac2);
            Console.WriteLine("Ağacın derinliği: "+derinlik);
            Console.WriteLine("Ağacın düğüm sayısı: " + agac.dugumsayi);
            int sayi = 1;
            int us = 0;
            while (sayi < 48)
            {
                sayi *= 2;
                us += 1;
            }
            Console.WriteLine("Ağaç dengeli olsa idi derinliği: "+agac.us);
            Console.WriteLine("Üc harfi verilen Milliparkın il adını bulma: "+agac.ilbulma("Spi")); 
            agac2.preOrder(agac2.getRoot()); 
            foreach(string i  in hash.Keys) { Console.WriteLine(hash[i]); };
            Console.WriteLine("ilan tarihini değiştirmek istediğiniz bir Milli park var ise 1 yok ise 0 giriniz: ");
            string girdi = Console.ReadLine();

            
            if (girdi == "1")
            {

                while (true)
                {
                    Console.WriteLine("ilan tarihini değiştirmek istediğiniz milli parkın adını giriniz(Çıkış yapmak için q tuşuna basınız): ");


                    string girilenad = Console.ReadLine();
                    if (girilenad == "q")
                    {
                        break;
                    }

                    Console.WriteLine("Yeni ilan tarihini giriniz");
                    string yeniilanyili = Console.ReadLine();

                    foreach (string i in hash.Keys)
                    {
                        if (i == girilenad)
                        {
                            Console.WriteLine("Eski millipark bilgleri: " + hash[i]);
                            int index = Array.IndexOf(milliparkadları, i);
                            MilliPark milliparkgecici = new MilliPark(milliparkadları[index], şehirler[index], yeniilanyili, yuzolcumler[index], paragraflar[index]);
                            hash[i] = milliparkgecici;
                            Console.WriteLine("Güncellenen millipark bilgileri: " + hash[i]);
                            break;
                        }
                    }

                }

            }

            Console.WriteLine("En büyük 3 MilliPark(Heap)");    
            heap.listele();


            SelectionSort selectionsort = new SelectionSort();
            int[] array = { 4, 1, 8, 6, 0, 23, 12, 54, 87, 34, 43, 76 };
            int size = 11;

            Console.WriteLine("**** Selection Sort ****");
            selectionsort.sort(array);
            
            foreach(int i in array) { Console.Write(i+",");}
            

            Console.ReadLine();
        }
        
    }
}
