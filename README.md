## Project Objective

**Note:** While this project benchmarks and optimizes data structures for insert and remove operations in a queue-like manner, it does not implement a strict queue data structure. Instead, it evaluates various data structures (dynamic arrays, hash-based linked lists, and red-black trees) for their efficiency in FIFO-based processing.

This project evaluates different data structures to optimize insert and remove operations in FIFO (First-In-First-Out) queue systems. The goal is to determine the most efficient solution for large data sets by performing benchmark tests on the following structures:

1. **Dynamic Array-Based Approach (Key-Value List):**
    - **Purpose:** Utilize a basic data structure to achieve fast insert operations.
    - **Issue:** Removing elements from the front of the queue requires shifting all remaining elements, resulting in O(n) complexity.
    - **Benchmark Result:** High computational cost and significant delays in removal operations for large data sets.

2. **Hash-Based + Doubly Linked List Approach (Normal Distribution):**
    - **Purpose:** Utilize a hash-based data structure to perform insert and remove operations in O(1) time complexity.
    - **Benchmark Result:** Achieved high performance under normal key distribution conditions.

3. **Hash-Based + Doubly Linked List Approach (Collision Scenario):**
    - **Purpose:** Simulate intentional hash collisions to analyze the worst-case performance of hash-based structures.
    - **Benchmark Result:** When key collisions increased, the linked list chain lengthened, and performance degraded towards O(n) complexity.

4. **Red-Black Tree-Based Approach:**
    - **Purpose:** Ensure stable and predictable O(log n) time complexity even under heavy key collision scenarios.
    - **Benchmark Result:** Provided more consistent and scalable performance compared to linked-list-based approaches in collision scenarios.

## Project Structure

```
DSA-Benchmark/
├── .gitignore
├── README.md
├── LICENSE
├── PerformanceQueueSolution.sln
└── src/
    ├── Program.cs
    ├── DataStructures/
    │   ├── NaiveKeyValueList.cs          // Dynamic array-based approach (Key-Value List)
    │   ├── HybridQueueStackDLL.cs        // Hash-Based + Doubly Linked List (Normal & Collision Handling)
    │   └── HybridQueueStackRB.cs         // Red-Black Tree-Based approach
    └── Utils/
        └── CollidingKey.cs               // Custom key type to simulate hash collisions
```

## Setup & Execution

1. **Clone Repository:**

   ```bash
   git clone https://github.com/yourusername/DSA-Benchmark.git
   cd DSA-Benchmark
   ```

2. **Open the Project:**
    - Use JetBrains Rider or Visual Studio to open the solution.

3. **Build the Solution:**
    - Compile the solution (`PerformanceQueueSolution.sln`).
    - If errors occur, verify file and namespace configurations.

4. **Run the Benchmark:**
    - When executed, the console will prompt for the number of operations (e.g., 10K).
    - Results will be displayed step by step.

## Benchmark Tests

- **Benchmark 1 (Naive Dynamic Array-Based Approach):**  
  Uses a dynamic array (List<T>) for insert operations, but removing elements from the front follows FIFO rules and results in O(n) complexity.

- **Benchmark 2 (Hash-Based + Doubly Linked List, Normal Distribution):**  
  With a naturally distributed key set, the hash-based structure combined with a doubly linked list ensures O(1) insert/remove operations.

- **Benchmark 3 (Hash-Based + Doubly Linked List, Collision Scenario):**  
  When all keys return the same hash value (`CollidingKey`), the linked list grows longer, leading to O(n) performance degradation.

- **Benchmark 4 (Red-Black Tree-Based Approach):**  
  Under the same collision scenario, a red-black tree structure ensures worst-case O(log n) complexity, providing stable and predictable performance.

## Key Findings

- **Dynamic array-based FIFO queues** perform poorly for large-scale systems due to inefficient O(n) removal operations.
- **Hash-Based + Doubly Linked List approach** is highly efficient under normal key distributions.
- **Hash collisions severely impact hash-based structures, increasing lookup and removal times.**
- **Red-black tree-based solutions provide predictable and scalable performance in high-collision environments.**

## Sample Benchmark Results

The following benchmark results were obtained using different dataset sizes:

| Data Size | Dynamic Array-Based (ms) | Hash-Based + DLL (ms) | Hash-Based + DLL (Collision) (ms) | Red-Black Tree (ms) |
|-----------|-------------------------|----------------------|----------------------------------|-------------------|
| 500       | 35                      | 1                    | 5                                | 3                 |
| 1000      | 36                      | 1                    | 16                               | 3                 |
| 10,000    | 43                      | 3                    | 938                              | 21                |
| 100,000   | 1795                     | 28                   | 83062                            | 197               |

## Further Analysis

For an in-depth review of the methodology, findings, and real-world implications of this benchmarking study, refer to our detailed research article:  
🔗 **[Read the full article on Medium](https://medium.com/@goktug8810)**

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

