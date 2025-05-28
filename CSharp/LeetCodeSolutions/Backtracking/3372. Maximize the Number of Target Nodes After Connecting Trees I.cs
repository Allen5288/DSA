public class Solution {
    public int[] MaxTargetNodes(int[][] edges1, int[][] edges2, int k) {
        int n = edges1.Length + 1, m = edges2.Length + 1;
        int[] count1 = Build(edges1, k);
        int[] count2 = Build(edges2, k - 1);
        int maxCount2 = 0;
        foreach (int c in count2) {
            if (c > maxCount2) {
                maxCount2 = c;
            }
        }
        int[] res = new int[n];
        for (int i = 0; i < n; i++) {
            res[i] = count1[i] + maxCount2;
        }
        return res;
    }

    private int[] Build(int[][] edges, int k) {
        int n = edges.Length + 1;
        List<List<int>> children = new List<List<int>>();
        for (int i = 0; i < n; i++) {
            children.Add(new List<int>());
        }
        foreach (var edge in edges) {
            children[edge[0]].Add(edge[1]);
            children[edge[1]].Add(edge[0]);
        }
        int[] res = new int[n];
        for (int i = 0; i < n; i++) {
            res[i] = Dfs(i, -1, children, k);
        }
        return res;
    }

    private int Dfs(int node, int parent, List<List<int>> children, int k) {
        if (k < 0) {
            return 0;
        }
        int res = 1;
        foreach (int child in children[node]) {
            if (child == parent) {
                continue;
            }
            res += Dfs(child, node, children, k - 1);
        }
        return res;
    }
}