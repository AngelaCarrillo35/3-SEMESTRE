# Software de Registro de Aportes de una Asociación

class Socio:
    def __init__(self, codigo, nombre, cedula, aporte):
        self.codigo = codigo
        self.nombre = nombre
        self.cedula = cedula
        self.aporte = aporte

    def mostrar(self):
        print(f"Código: {self.codigo}")
        print(f"Nombre: {self.nombre}")
        print(f"Cédula: {self.cedula}")
        print(f"Aporte: ${self.aporte:.2f}")
        print("-" * 30)

# Vector para almacenar los socios
socios = []

def registrar_socio():
    print("\n=== REGISTRAR SOCIO ===")
    codigo = input("Ingrese código: ")
    nombre = input("Ingrese nombre: ")
    cedula = input("Ingrese cédula: ")
    aporte = float(input("Ingrese valor del aporte: "))

    nuevo_socio = Socio(codigo, nombre, cedula, aporte)
    socios.append(nuevo_socio)

    print("Socio registrado correctamente.")

def mostrar_socios():
    print("\n=== LISTA DE SOCIOS ===")

    if len(socios) == 0:
        print("No existen registros.")
    else:
        for socio in socios:
            socio.mostrar()

def buscar_socio():
    print("\n=== BUSCAR SOCIO ===")
    codigo = input("Ingrese el código del socio: ")

    encontrado = False

    for socio in socios:
        if socio.codigo == codigo:
            socio.mostrar()
            encontrado = True
            break

    if not encontrado:
        print("Socio no encontrado.")

def total_aportes():
    total = 0

    for socio in socios:
        total += socio.aporte

    print(f"\nTotal de aportes registrados: ${total:.2f}")

# Menú principal
while True:
    print("\n===== SISTEMA DE APORTES =====")
    print("1. Registrar socio")
    print("2. Mostrar socios")
    print("3. Buscar socio")
    print("4. Total de aportes")
    print("5. Salir")

    opcion = input("Seleccione una opción: ")

    if opcion == "1":
        registrar_socio()

    elif opcion == "2":
        mostrar_socios()

    elif opcion == "3":
        buscar_socio()

    elif opcion == "4":
        total_aportes()

    elif opcion == "5":
        print("Programa finalizado.")
        break

    else:
        print("Opción incorrecta.")