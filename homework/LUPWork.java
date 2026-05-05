import java.util.Scanner;
import java.util.Locale;

public class LUPWork {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in).useLocale(Locale.US);

        System.out.println("=== Домашня робота: LUP-розкладання (Варіант 4) ===");

        int n = 4;
        double[][] A = new double[n][n];
        double[] b = new double[n];

        System.out.println("Введіть коефіцієнти матриці A (по рядках):");
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                System.out.printf("A[%d][%d]: ", i + 1, j + 1);
                A[i][j] = sc.nextDouble();
            }
        }

        System.out.println("Введіть вільні члени (вектор b):");
        for (int i = 0; i < n; i++) {
            System.out.printf("b[%d]: ", i + 1);
            b[i] = sc.nextDouble();
        }

        double[][] A_orig = copyMatrix(A);

        printSystem(A_orig, b);

        double[][] L = new double[n][n];
        double[][] U = new double[n][n];
        int[] P = new int[n];
        for (int i = 0; i < n; i++) P[i] = i;

        lupDecompose(A, L, U, P, n);

        printLUP(L, U, P, n);

        double[] x = solveLUP(L, U, P, b, n);

        System.out.println("\nРезультат (вектор x):");
        for (int i = 0; i < n; i++) {
            System.out.printf("x%d = %.4f\n", i + 1, x[i]);
        }
    }

    public static void lupDecompose(double[][] A, double[][] L, double[][] U, int[] P, int n) {
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                U[i][j] = A[i][j];

        for (int i = 0; i < n; i++) L[i][i] = 1.0; 

        for (int i = 0; i < n; i++) {
            int pivot = i;
            for (int j = i + 1; j < n; j++) {
                if (Math.abs(U[j][i]) > Math.abs(U[pivot][i])) pivot = j;
            }

            double[] tempRow = U[i]; U[i] = U[pivot]; U[pivot] = tempRow;
            int tempP = P[i]; P[i] = P[pivot]; P[pivot] = tempP;
            for (int j = 0; j < i; j++) {
                double tempL = L[i][j]; L[i][j] = L[pivot][j]; L[pivot][j] = tempL;
            }

            for (int j = i + 1; j < n; j++) {
                L[j][i] = U[j][i] / U[i][i];
                for (int k = i; k < n; k++) {
                    U[j][k] -= L[j][i] * U[i][k];
                }
            }
        }
    }

    public static double[] solveLUP(double[][] L, double[][] U, int[] P, double[] b, int n) {
        double[] Pb = new double[n];
        for (int i = 0; i < n; i++) Pb[i] = b[P[i]];

        double[] y = new double[n];
        for (int i = 0; i < n; i++) {
            double sum = 0;
            for (int j = 0; j < i; j++) sum += L[i][j] * y[j];
            y[i] = Pb[i] - sum;
        }

        double[] x = new double[n];
        for (int i = n - 1; i >= 0; i--) {
            double sum = 0;
            for (int j = i + 1; j < n; j++) sum += U[i][j] * x[j];
            x[i] = (y[i] - sum) / U[i][i];
        }
        return x;
    }

    static void printSystem(double[][] A, double[] b) {
        System.out.println("\nЗадана система рівнянь:");
        for (int i = 0; i < A.length; i++) {
            for (int j = 0; j < A.length; j++) {
                System.out.printf("%s%.1fx%d ", (A[i][j] >= 0 && j > 0 ? "+" : ""), A[i][j], j + 1);
            }
            System.out.printf("= %.1f\n", b[i]);
        }
    }

    static void printLUP(double[][] L, double[][] U, int[] P, int n) {
        System.out.println("\nМатриця L (нижня трикутна):");
        printMat(L);
        System.out.println("\nМатриця U (верхня трикутна):");
        printMat(U);
        System.out.println("\nМатриця перестановки P (індекси):");
        for (int i : P) System.out.print(i + " ");
        System.out.println("\n(Або у вигляді матриці 4x4):");
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                System.out.print((P[i] == j ? "1 " : "0 "));
            }
            System.out.println();
        }
    }

    static void printMat(double[][] m) {
        for (double[] row : m) {
            for (double val : row) System.out.printf("%8.3f ", val);
            System.out.println();
        }
    }

    static double[][] copyMatrix(double[][] a) {
        double[][] res = new double[a.length][a.length];
        for (int i = 0; i < a.length; i++) res[i] = a[i].clone();
        return res;
    }
}