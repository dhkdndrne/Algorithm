#include<iostream>
#include <vector>
#include <algorithm>

using namespace std;

int main()
{
	int cnt;
	cin >> cnt;

	vector<int> rope;
	for (int i = 0;i < cnt;i++)
	{
		int num = 0;
		cin >> num;
		rope.push_back(num);
	}
	sort(rope.begin(), rope.end(), greater<int>());

	int result = 0;
	for (int i = 0; i < rope.size();i++)
	{
		int sum = rope[i] * (i + 1);
		if (sum > result)
			result = sum;
	}

	cout << result;
}