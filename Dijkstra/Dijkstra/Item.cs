﻿namespace Dijkstra
{
    /*
    * 우선순위큐 - 리스트로 구현
    * Item - 정점번호와 해당 정점의 최단거리 저장
    * 우선순위큐 - Item을 저장하는 리스트
    * Dequeue() : 우선순위가 높은(최단거리가 가장 작은) Item 삭제
    * Peak() : 우선순위가 높은 Item의 최단거리, 정점 번호 반환
    */
    class Item
    {
        public int Dist { get; set; } //정점의 dist(최단거리) 값
        public int Vertex { get; set; } //정점 번호
    }
}