namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        IdCategoria = c.Int(nullable: false, identity: true),
                        NombreCategoria = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdCategoria);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        IdProducto = c.Int(nullable: false, identity: true),
                        NombreProducto = c.String(nullable: false),
                        Precio = c.Double(nullable: false),
                        Descripcion = c.String(nullable: false),
                        Imagen = c.String(nullable: false),
                        IdCategoria = c.Int(nullable: false),
                        IdProveedor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProducto)
                .ForeignKey("dbo.Categorias", t => t.IdCategoria, cascadeDelete: false)
                .ForeignKey("dbo.Proveedores", t => t.IdProveedor, cascadeDelete: false)
                .Index(t => t.IdCategoria)
                .Index(t => t.IdProveedor);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        IdCompra = c.Int(nullable: false, identity: true),
                        CantidadCompra = c.Int(nullable: false),
                        FechaCompra = c.DateTime(nullable: false),
                        IdProducto = c.Int(nullable: false),
                        IdProveedor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCompra)
                .ForeignKey("dbo.Productos", t => t.IdProducto, cascadeDelete: false)
                .ForeignKey("dbo.Proveedores", t => t.IdProveedor, cascadeDelete: false)
                .Index(t => t.IdProducto)
                .Index(t => t.IdProveedor);
            
            CreateTable(
                "dbo.InventarioFinals",
                c => new
                    {
                        IdInventarioFinal = c.Int(nullable: false, identity: true),
                        CantidadCompra = c.Int(nullable: false),
                        CantidadVenta = c.Int(nullable: false),
                        Existencia = c.Int(nullable: false),
                        IdProducto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdInventarioFinal)
                .ForeignKey("dbo.Productos", t => t.IdProducto, cascadeDelete: false)
                .Index(t => t.IdProducto);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        IdVenta = c.Int(nullable: false, identity: true),
                        CantidadVenta = c.Int(nullable: false),
                        FechaVenta = c.DateTime(nullable: false),
                        IdProducto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdVenta)
                .ForeignKey("dbo.Productos", t => t.IdProducto, cascadeDelete: false)
                .Index(t => t.IdProducto);
            
            CreateTable(
                "dbo.DatosUsuarios",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Usuario = c.String(nullable: false),
                        Contra = c.String(nullable: false),
                        Carnet = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Roles = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdUsuario);
            
            CreateTable(
                "dbo.Proveedores",
                c => new
                    {
                        IdProveedor = c.Int(nullable: false, identity: true),
                        NombreProveedor = c.String(nullable: false),
                        Telefono = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProveedor);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productos", "IdProveedor", "dbo.Proveedores");
            DropForeignKey("dbo.Compras", "IdProveedor", "dbo.Proveedores");
            DropForeignKey("dbo.Productos", "IdCategoria", "dbo.Categorias");
            DropForeignKey("dbo.Ventas", "IdProducto", "dbo.Productos");
            DropForeignKey("dbo.InventarioFinals", "IdProducto", "dbo.Productos");
            DropForeignKey("dbo.Compras", "IdProducto", "dbo.Productos");
            DropIndex("dbo.Ventas", new[] { "IdProducto" });
            DropIndex("dbo.InventarioFinals", new[] { "IdProducto" });
            DropIndex("dbo.Compras", new[] { "IdProveedor" });
            DropIndex("dbo.Compras", new[] { "IdProducto" });
            DropIndex("dbo.Productos", new[] { "IdProveedor" });
            DropIndex("dbo.Productos", new[] { "IdCategoria" });
            DropTable("dbo.Proveedores");
            DropTable("dbo.DatosUsuarios");
            DropTable("dbo.Ventas");
            DropTable("dbo.InventarioFinals");
            DropTable("dbo.Compras");
            DropTable("dbo.Productos");
            DropTable("dbo.Categorias");
        }
    }
}
