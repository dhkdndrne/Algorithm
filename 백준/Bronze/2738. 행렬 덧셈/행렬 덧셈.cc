#include <iostream>
#include <vector>
using namespace std;


int main() 
{
    int row, col;
    cin >> row >> col; cin.ignore();
    vector<vector<int> > matrix(row);

    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            int t;
            cin >> t; cin.ignore();
            matrix[i].push_back(t);
        }
    }
    for (int i = 0; i < row; i++) {
        for (int j = 0; j < col; j++)
        {
            int t;
            cin >> t; cin.ignore();
            matrix[i][j] = matrix[i][j] + t;
        }
    }


    for (int i = 0; i < row; i++) {
        for (int j = 0; j < col; j++)
        {
            cout << matrix[i][j] << ' ';
        }
        cout << endl;
    }

}