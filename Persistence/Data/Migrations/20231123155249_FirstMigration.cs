﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
/*             migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "gama_producto",
                columns: table => new
                {
                    gama = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion_texto = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion_html = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    imagen = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.gama);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "oficina",
                columns: table => new
                {
                    codigo_oficina = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ciudad = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pais = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    region = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    codigo_postal = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    linea_direccion1 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    linea_direccion2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.codigo_oficina);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    codigo_producto = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    gama = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dimensiones = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    proveedor = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cantidad_en_stock = table.Column<short>(type: "smallint", nullable: false),
                    precio_venta = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    precio_proveedor = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.codigo_producto);
                    table.ForeignKey(
                        name: "FK_producto_gama_gama_producto_gama",
                        column: x => x.gama,
                        principalTable: "gama_producto",
                        principalColumn: "gama");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "empleado",
                columns: table => new
                {
                    codigo_empleado = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    apellido1 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    apellido2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    extension = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    codigo_oficina = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    codigo_jefe = table.Column<int>(type: "int", nullable: true),
                    puesto = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.codigo_empleado);
                    table.ForeignKey(
                        name: "FK_empleado_codigo_jefe_empleado_codigo_empleado",
                        column: x => x.codigo_jefe,
                        principalTable: "empleado",
                        principalColumn: "codigo_empleado");
                    table.ForeignKey(
                        name: "FK_empleado_codigo_oficina_oficina_codigo_oficina",
                        column: x => x.codigo_oficina,
                        principalTable: "oficina",
                        principalColumn: "codigo_oficina");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    codigo_cliente = table.Column<int>(type: "int", nullable: false),
                    nombre_cliente = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre_contacto = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    apellido_contacto = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fax = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    linea_direccion1 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    linea_direccion2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ciudad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    region = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pais = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    codigo_postal = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    codigo_empleado_rep_ventas = table.Column<int>(type: "int", nullable: true),
                    limite_credito = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.codigo_cliente);
                    table.ForeignKey(
                        name: "FK_cliente_codigo_empleado_rep_ventas_empleado_codigo_empleado",
                        column: x => x.codigo_empleado_rep_ventas,
                        principalTable: "empleado",
                        principalColumn: "codigo_empleado");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pago",
                columns: table => new
                {
                    codigo_cliente = table.Column<int>(type: "int", nullable: false),
                    id_transaccion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    forma_pago = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fecha_pago = table.Column<DateOnly>(type: "date", nullable: false),
                    total = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.codigo_cliente, x.id_transaccion })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "FK_pago_codigo_cliente_cliente_codigo_cliente",
                        column: x => x.codigo_cliente,
                        principalTable: "cliente",
                        principalColumn: "codigo_cliente");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    codigo_pedido = table.Column<int>(type: "int", nullable: false),
                    fecha_pedido = table.Column<DateOnly>(type: "date", nullable: false),
                    fecha_esperada = table.Column<DateOnly>(type: "date", nullable: false),
                    fecha_entrega = table.Column<DateOnly>(type: "date", nullable: true),
                    estado = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    comentarios = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    codigo_cliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.codigo_pedido);
                    table.ForeignKey(
                        name: "FK_pedido_codigo_cliente_cliente_codigo_cliente",
                        column: x => x.codigo_cliente,
                        principalTable: "cliente",
                        principalColumn: "codigo_cliente");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "detalle_pedido",
                columns: table => new
                {
                    codigo_pedido = table.Column<int>(type: "int", nullable: false),
                    codigo_producto = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio_unidad = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    numero_linea = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.codigo_pedido, x.codigo_producto })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "FK_detalle_pedido_codigo_pedido_pedido_codigo_pedido",
                        column: x => x.codigo_pedido,
                        principalTable: "pedido",
                        principalColumn: "codigo_pedido");
                    table.ForeignKey(
                        name: "FK_detalle_pedido_codigo_producto_producto_codigo_producto",
                        column: x => x.codigo_producto,
                        principalTable: "producto",
                        principalColumn: "codigo_producto");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "FK_cliente_codigo_empleado_rep_ventas_empleado_codigo_empleado",
                table: "cliente",
                column: "codigo_empleado_rep_ventas");

            migrationBuilder.CreateIndex(
                name: "FK_detalle_pedido_codigo_producto_producto_codigo_producto",
                table: "detalle_pedido",
                column: "codigo_producto");

            migrationBuilder.CreateIndex(
                name: "FK_empleado_codigo_jefe_empleado_codigo_empleado",
                table: "empleado",
                column: "codigo_jefe");

            migrationBuilder.CreateIndex(
                name: "FK_empleado_codigo_oficina_oficina_codigo_oficina",
                table: "empleado",
                column: "codigo_oficina");

            migrationBuilder.CreateIndex(
                name: "FK_pedido_codigo_cliente_cliente_codigo_cliente",
                table: "pedido",
                column: "codigo_cliente");

            migrationBuilder.CreateIndex(
                name: "FK_producto_gama_gama_producto_gama",
                table: "producto",
                column: "gama"); */
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /* migrationBuilder.DropTable(
                name: "detalle_pedido");

            migrationBuilder.DropTable(
                name: "pago");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "gama_producto");

            migrationBuilder.DropTable(
                name: "empleado");

            migrationBuilder.DropTable(
                name: "oficina"); */
        }
    }
}
