using System;
using System.Collections;
using System.Collections.Generic;

namespace BFS       
{
    public class BusStation<T>
    {
        public T Name { get; set; }

        public BusStation( T name)
        {
            nextStations = new List<BusStation<T>>();
            Name = name;
        }

        public List<BusStation<T>> nextStations;
    }

    public class BusMap<T>
    {
        private BusStation<T> HeadStation;

        public BusMap()
        {

        }

        public BusMap(BusStation<T> station)
        {
            HeadStation = station;
        }

        public void ChooseHeadStation(BusStation<T> station)
        {
            HeadStation = station;
        }

        public BusStation<T> CreateStation(T data)
        {
            return new BusStation<T>(data);
        }

        public void CreateSimplexWay(BusStation<T> stationA, BusStation<T> stationB)
        {
            if (!stationA.nextStations.Contains(stationB))
            {
                stationA.nextStations.Add(stationB);
            }
            else
            {
                throw new Exception($"station: {stationB.Name} exists");
            }
        }

        public void CreateDuplexWay(BusStation<T> stationA, BusStation<T> stationB)
        {
            bool error = false;

            if (!stationA.nextStations.Contains(stationB))
            {
                stationA.nextStations.Add(stationB);
            }
            else
            {
                error = true;
            }

            if (!stationB.nextStations.Contains(stationA))
            {
                stationB.nextStations.Add(stationA);
            }
            else
            {
                if (error)
                {
                    throw new Exception("both stations have way to each other");
                }

                throw new Exception($"station: {stationB.Name} already had station: {stationA.Name}");
            }

            if (error)
            {
                throw new Exception($"station: {stationA.Name} already had station: {stationB.Name}");
            }
        }

        public bool BfsSearch(BusStation<T> station)
        {
            Queue<BusStation<T>> stations = new Queue<BusStation<T>>();

            stations.Enqueue(HeadStation);

            while (stations.Count != 0)
            {
                if (stations.Peek().Equals(station))
                {
                    Console.WriteLine($"the way to station: {station.Name} is founded!");

                    return true;
                }
                else
                {
                    if (stations.Peek().nextStations.Count != 0)
                    {
                        foreach (var s in stations.Peek().nextStations)
                        {
                            bool exists = false;

                            foreach (var qs in stations)
                            {
                                if (qs == s)
                                {
                                    exists = true;
                                }
                            }

                            if (!exists)
                            {
                                stations.Enqueue(s);
                            }
                        }

                        
                    }

                    stations.Dequeue();
                }
            }

            Console.WriteLine($"we cannot find way form station: {HeadStation} to station: {stations}, try to find another one");

            return false;
        }

        public bool DfsSearch(BusStation<T> needed)
        {
            return DfsSearch(HeadStation, needed);
        }

        private bool DfsSearch(BusStation<T> current, BusStation<T> needed)
        {
            
            if (current.Equals(needed))
            {
                Console.WriteLine($"the way to station: {needed.Name} from station: {HeadStation.Name} is exists");

                return true;
            }
            else
            {
                if (current.nextStations.Count != 0)
                {
                    foreach (var st in current.nextStations)
                    {
                        DfsSearch(st, needed);
                    }
                }

                return false;
            }

            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BusMap<string> map = new BusMap<string>();

            BusStation<string>[] stations = new BusStation<string>[10];

            stations[0] = new BusStation<string>("station-1");

            map.ChooseHeadStation(stations[0]);

            for (int i = 1; i < stations.Length; i++)
            {
                stations[i] = new BusStation<string>($"station-{i + 1}");
            }

            map.CreateSimplexWay(stations[0], stations[1]);
            map.CreateSimplexWay(stations[0], stations[2]);
            map.CreateSimplexWay(stations[1], stations[3]);
            map.CreateSimplexWay(stations[2], stations[3]);
            map.CreateSimplexWay(stations[3], stations[4]);
            map.CreateSimplexWay(stations[3], stations[5]);
            map.CreateSimplexWay(stations[3], stations[6]);
            map.CreateSimplexWay(stations[6], stations[4]);
            map.CreateSimplexWay(stations[6], stations[5]);
            map.CreateSimplexWay(stations[6], stations[7]);
            map.CreateSimplexWay(stations[7], stations[8]);
            map.CreateSimplexWay(stations[8], stations[5]);
            map.CreateSimplexWay(stations[8], stations[9]);

            map.BfsSearch(stations[9]);
            map.DfsSearch(stations[9]);
        }
    }
}
