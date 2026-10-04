# GUÍA DE PRÁCTICAS #04
# IMPLEMENTACIÓN Y REPRESENTACIÓN DE ÁRBOLES Y GRAFOS
# Actividad: Gráfica de grafos

import time
import networkx as nx
import matplotlib.pyplot as plt

# FUNCIÓN PARA MOSTRAR LA REPORTERÍA

def mostrar_reporte(nombre, grafo):

    print("\n" + "=" * 60)
    print("REPORTE:", nombre)
    print("=" * 60)

    print("Nodos:", list(grafo.nodes()))
    print("Aristas:", list(grafo.edges()))

    print("Cantidad de nodos:", grafo.number_of_nodes())
    print("Cantidad de aristas:", grafo.number_of_edges())

    print("\nGrado de cada nodo:")

    for nodo, grado in grafo.degree():
        print(" ", nodo, ":", grado)


# FUNCIÓN PARA GRAFICAR EL GRAFO

def graficar_grafo(nombre, grafo):

    plt.figure(figsize=(8, 6))

    posicion = nx.spring_layout(grafo, seed=42)

    nx.draw(
        grafo,
        posicion,
        with_labels=True,
        node_size=1800,
        font_size=10,
        width=2
    )

    plt.title(nombre)

    plt.tight_layout()

    plt.show()


# PROGRAMA PRINCIPAL

def main():

    # Inicia el tiempo
    inicio = time.perf_counter()

    # EJEMPLO 1
    # Conexiones entre áreas de una institución

    grafo1 = nx.Graph()

    grafo1.add_edges_from([
        ("Administración", "Biblioteca"),
        ("Administración", "Laboratorio"),
        ("Biblioteca", "Laboratorio"),
        ("Biblioteca", "Aula"),
        ("Laboratorio", "Aula"),
        ("Aula", "Bienestar")
    ])

    # EJEMPLO 2
    # Red de dispositivos

    grafo2 = nx.Graph()

    grafo2.add_edges_from([
        ("Router", "PC1"),
        ("Router", "PC2"),
        ("Router", "Servidor"),
        ("PC1", "Impresora"),
        ("PC2", "Laptop"),
        ("Servidor", "PC2"),
        ("Servidor", "PC3")
    ])

    # MOSTRAR REPORTES

    mostrar_reporte(
        "Ejemplo 1 - Conexiones entre áreas",
        grafo1
    )
    mostrar_reporte(
        "Ejemplo 2 - Red de dispositivos",
        grafo2
    )

    # MOSTRAR GRÁFICOS
    graficar_grafo(
        "Ejemplo 1 - Conexiones entre áreas",
        grafo1
    )
    graficar_grafo(
        "Ejemplo 2 - Red de dispositivos",
        grafo2
    )

    # TIEMPO DE EJECUCIÓN

    fin = time.perf_counter()

    tiempo = fin - inicio

    print("\n" + "=" * 60)
    print("TIEMPO DE EJECUCIÓN")
    print("=" * 60)

    print(f"Tiempo total: {tiempo:.6f} segundos")

# EJECUTAR PROGRAMA

if __name__ == "__main__":
    main()