#include <iostream>
#include <vector>
using namespace std;


vector<pair<int, int> > v;

void Hanoi(int n, int from, int by, int to)
{
	if (n == 1) v.push_back(make_pair(from, to));
	else
	{
		Hanoi(n - 1, from, to, by);
		v.push_back(make_pair(from, to));
		Hanoi(n - 1, by, from,to );
	}
}

int main() 
{
	ios_base::sync_with_stdio(false);

	cin.tie(NULL);
	cout.tie(NULL);
	int n; cin >> n;
	Hanoi(n, 1, 2, 3);

	cout << v.size() << endl;
	for (int i = 0; i < v.size(); i++)
	{
		cout << v[i].first << " " << v[i].second << "\n";
	}
}