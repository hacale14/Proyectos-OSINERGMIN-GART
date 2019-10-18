function select_all(obj){
    var valor=obj.checked;
    if(valor){
        for(var i=0; i<document.forms[0].chkBox.length; i++){
            document.forms[0].chkBox[i].checked=true;
        }
    }else{
        for(var j=0; j<document.forms[0].chkBox.length; j++){
            document.forms[0].chkBox[j].checked=false;
        }
    }
}
function limpia_datosBuscar(){
	document.forms[0].method.value = "limpiaDatosBuscar";
	document.forms[0].submit();
}

function limpia_datosActualizar(){
	document.forms[0].method.value = "limpiaDatosActualizar";
	document.forms[0].submit();
}

//SCRIPTS GENERALES ---------------------------------------------------------------------
function obtenerSeleccionado(){
	var count=0; var rad_val;
	if(document.forms[0].chkBox == null){
		alert('No hay ningún registro seleccionado');
   		return false;
	}
	for (var i=0; i < document.forms[0].chkBox.length; i++){
   		if (document.forms[0].chkBox[i].checked){
      		count+=1;
      		rad_val = document.forms[0].chkBox[i].value;
      	}
   	}
   	if (document.forms[0].chkBox != null) {
   		if (document.forms[0].chkBox.checked){
      		count+=1;
      		rad_val = document.forms[0].chkBox.value;
    	}
    }
   	if(count==1){
		document.getElementById('valorModificado').value=rad_val;
   		return true;
   	}else{
   		alert('Elegir un solo Registro');
		return false;
   	}
}
function obtenerEliminados(){
    if(document.forms[0].chkBox == null){
        alert('No hay ningún registro seleccionado');
        return false;
    }
    var arr= new Array(document.forms[0].chkBox.length);
    var rad_val;var count=0;
    for (var i=0; i < document.forms[0].chkBox.length; i++){
        if (document.forms[0].chkBox[i].checked){
            count+=1;
            rad_val = document.forms[0].chkBox[i].value;
            arr[i]=rad_val;
        }
    }
    if (document.forms[0].chkBox != null) {
        if (document.forms[0].chkBox.checked){
            count+=1;
            rad_val = document.forms[0].chkBox.value;
            arr[i]=rad_val;
        }
    }
    if(count==0){
        alert('Debe seleccionar por lo menos un registro a eliminar');
        return false;
    }
    if(confirm('¿Desea eliminar Registro(s)?')){
        document.getElementById('valoresEliminados').value=arr;
        return true;
    }
    return false;
}
function obtenerSeleccionadosVarios(){
	if(document.forms[0].chkBox == null){
        alert('No hay ningún registro seleccionado');
        return false;
    }
    var arr= new Array(document.forms[0].chkBox.length);
    var rad_val;var count=0;
    for (var i=0; i < document.forms[0].chkBox.length; i++){
        if (document.forms[0].chkBox[i].checked){
            count+=1;
            rad_val = document.forms[0].chkBox[i].value;
            arr[i]=rad_val;
        }
    }
    if (document.forms[0].chkBox != null) {
        if (document.forms[0].chkBox.checked){
            count+=1;
            rad_val = document.forms[0].chkBox.value;
            arr[i]=rad_val;
        }
    }
    if(count==0){
        alert('Debe seleccionar por lo menos un valor');
        return false;
    }
    document.getElementById('valorSeleccionados').value=arr;
    return true;
}


//logeo - INDEX ---------------------------------------------------------------------
function logeo(){
	document.frmLogin.method.value = "login";
	document.frmLogin.submit();
}

function limpiar(){
	document.frmLogin.method.value = "limpiar";
	document.frmLogin.submit();
}

//restablecer contrasenha
function reesContrasenha_frmPrincipal(){
	document.frmPrincipal.method.value = "actualizarRecordarContrasenha";
	document.frmPrincipal.submit();
}

//USUARIO ---------------------------------------------------------------------------
//BUSCAR USUARIO
function nuevoUsuario_frmUsuario(){
	document.frmUsuario.method.value = "nuevo";
	document.frmUsuario.submit();
}
function modificarUsuario_frmUsuario(){
	if(obtenerSeleccionado()){
		document.frmUsuario.method.value = "modificar";
		document.frmUsuario.submit();
	}
}
function ajaxListaUsuario(){
    $('cargando').update("Cargando...");
    document.getElementById('response').style.display = "none";
    var options={
        method: 'get',
        parameters:{
        	nombres: encodeURIComponent(document.getElementById('nombres').value),
        	apepaterno: encodeURIComponent(document.getElementById('apepaterno').value),
        	apematerno: encodeURIComponent(document.getElementById('apematerno').value),
        	sobrenombre: document.getElementById('sobrenombre').value,
        },
        onSuccess: function(){
            $('cargando').update("");
            document.getElementById('response').style.display = "block";
        }
    };
    new Ajax.Updater('response','buscarUsuario.action', options);
}
function ajaxEliminarUsuario(){
	if(obtenerEliminados()){
	    var options={
	        method: 'get',
	        parameters:{
	        	valoresEliminados: document.getElementById('valoresEliminados').value,
	        }
	    };
	    new Ajax.Updater('response','eliminarUsuario.action', options);
    }
}
//REGISTRAR - MODIFICAR USUARIO
function aceptarUsuario_frmUsuario(){
	document.frmUsuario.method.value = "actualizar";
	document.frmUsuario.submit();
}
function cancelarUsuario_frmUsuario(){
	document.frmUsuario.method.value = "inicio";
	document.frmUsuario.submit();
}

//CONFIGURACION PERSONAL
function configUsuario_frmUsuario(){
	document.frmUsuario.method.value = "actualizarConfiguracionPersonal";
	document.frmUsuario.submit();
}

//CAMBIAR CONTRASENHA
function camContrasenha_frmUsuario(){
	document.frmUsuario.method.value = "actualizarContrasenha";
	document.frmUsuario.submit();
}

//PERFIL ---------------------------------------------------------------------------
//BUSCAR PERFIL
function nuevoUsuario_frmPerfil(){
	document.frmPerfil.method.value = "nuevo";
	document.frmPerfil.submit();
}
function modificarPerfil_frmPerfil(){
	if(obtenerSeleccionado()){
		document.frmPerfil.method.value = "modificar";
		document.frmPerfil.submit();
	}
}
function ajaxEliminarPerfil(){
	if(obtenerEliminados()){
	    var options={
	        method: 'get',
	        parameters:{
	        	valoresEliminados: document.getElementById('valoresEliminados').value,
	        }
	    };
	    new Ajax.Updater('response','eliminarPerfil.action', options);
    }
}

//REGISTRAR - MODIFICAR PERFIL
function aceptarPerfil_frmPerfil(){
	if(obtenerSeleccionadosVarios()){
		document.frmPerfil.method.value = "actualizar";
		document.frmPerfil.submit();
	}
}
function cancelarPerfil_frmPerfil(){
	document.frmPerfil.method.value = "inicio";
	document.frmPerfil.submit();
}

//LIBRO ---------------------------------------------------------------------------
//BUSCAR LIBRO
function importarLibro_frmLibro(){
	//document.frmLibro.method.value = "importar";
	//document.frmLibro.submit();
	window.open("importarLibro.action" , "ventana1" , "width=800,height=800,scrollbars=1,resizable=1") 
}
function nuevoLibro_frmLibro(){
	document.frmLibro.method.value = "nuevo";
	document.frmLibro.submit();
}
function modificarLibro_frmLibro(){
	if(obtenerSeleccionado()){
		
		document.frmLibro.method.value = "modificar";
		document.frmLibro.submit();
	}
}
function consultarLibro_frmLibro(){
	if(obtenerSeleccionado()){
		document.frmLibro.method.value = "consultar";
		document.frmLibro.submit();
	}
}
function ajaxListaLibro(){
    $('cargando').update("Cargando...");
    document.getElementById('response').style.display = "none";
    var options={
        method: 'get',
        parameters:{
        	titulo: encodeURIComponent(document.getElementById('titulo').value),
        	codigo: document.getElementById('codigo').value,
        	isbn: document.getElementById('isbn').value,
        	editorial: encodeURIComponent(document.getElementById('editorial').value),
        	categoria: encodeURIComponent(document.getElementById('categoria').value),
        	proveedor_id:  document.getElementById('proveedor_id').value,
        	autor:  encodeURIComponent(document.getElementById('autor').value),
        },
        onSuccess: function(){
            $('cargando').update("");
            document.getElementById('response').style.display = "block";
        }
    };
    new Ajax.Updater('response','buscarLibro.action', options);
}
function ajaxEliminarLibro(){
	if(obtenerEliminados()){
	    var options={
	        method: 'get',
	        parameters:{
	        	valoresEliminados: document.getElementById('valoresEliminados').value,
	        }
	    };
	    new Ajax.Updater('response','eliminarLibro.action', options);
    }
}

//REGISTRAR LIBRO
function guardarLibro_frmLibro(){
    document.frmLibro.method.value = "uploadFileBD";
	document.frmLibro.submit();
}

//MODIFICAR LIBRO
function cancelarLibro_frmLibro(){
	document.frmLibro.method.value = "inicio";
	document.frmLibro.submit();
}
function aceptarLibro_frmLibro(){
    document.frmLibro.method.value = "modificarBD";
	document.frmLibro.submit();
}

//TERCERO ---------------------------------------------------------------------------
//BUSCAR TERCERO
function nuevoTercero_frmTercero(){
	document.frmTercero.method.value = "nuevo";
	document.frmTercero.submit();
}
function modificarTercero_frmTercero(){
	if(obtenerSeleccionado()){
		document.frmTercero.method.value = "modificar";
		document.frmTercero.submit();
	}
}
function ajaxListaTercero(){

}

//REGISTRAR - MODIFICAR TERCERO
function aceptarTercero_frmTercero(){
	document.frmTercero.method.value = "actualizar";
	document.frmTercero.submit();
}
function cancelarTercero_frmTercero(){
	document.frmTercero.method.value = "inicio";
	document.frmTercero.submit();
}

//ALMACEN ---------------------------------------------------------------------------
//BUSCAR ALMACEN
function nuevoAlmacen_frmAlmacen(){
	document.frmAlmacen.method.value = "nuevo";
	document.frmAlmacen.submit();
}

function modificarAlmacen_frmAlmacen(){
	if(obtenerSeleccionado()){
		document.frmAlmacen.method.value = "modificar";
		document.frmAlmacen.submit();
	}
}

function consultarAlmacen_frmAlmacen(){
	if(obtenerSeleccionado()){
		document.frmAlmacen.method.value = "consultar";
		document.frmAlmacen.submit();
	}
}

function consultarVentasAlmacen_frmAlmacen(){
	if(obtenerSeleccionado()){
		document.frmAlmacen.method.value = "consultarVentas";
		document.frmAlmacen.submit();
	}
}

function seleccione_lista_frmAlmacen(){
	window.open("almacen.htm?method=listaAlmacen", "ventana1" , "width=800,height=800,scrollbars=NO") 
}

function seleccione_lista_frmAlmacenOrigen(){
	window.open("almacen.htm?method=listaAlmacenOrigen", "ventana1" , "width=800,height=800,scrollbars=NO") 
}

function seleccione_lista_frmAlmacenDestino(){
	window.open("almacen.htm?method=listaAlmacenDestino", "ventana1" , "width=800,height=800,scrollbars=NO") 
}
function seleccione_lista_frmProducto(){
	window.open("libro.htm?method=listaLibro", "ventana1" , "width=800,height=800,scrollbars=NO") 
}

function seleccione_frmAlmacen(){
	if(obtenerSeleccionado()){
		document.frmAlmacen.method.value = "seleccionar";
		document.frmAlmacen.submit();
	}
}

function seleccione_frmAlmacenOrigen(){
	if(obtenerSeleccionado()){
		document.frmAlmacen.method.value = "seleccionarOrigen";
		document.frmAlmacen.submit();
	}
}

function seleccione_frmAlmacenDestino(){
	if(obtenerSeleccionado()){
		document.frmAlmacen.method.value = "seleccionarDestino";
		document.frmAlmacen.submit();
	}
}

function seleccione_frmLibro(){
	if(obtenerSeleccionado()){
		document.frmLibro.method.value = "seleccionar";
		document.frmLibro.submit();
	}
}

function ajaxListaAlmacen(){
    $('cargando').update("Cargando...");
    document.getElementById('response').style.display = "none";
    var options={
        method: 'get',
        parameters:{
        	nombre: encodeURIComponent(document.getElementById('nombre').value),        	
        	distrito: encodeURIComponent(document.getElementById('distrito').value),
        },
        onSuccess: function(){
            $('cargando').update("");
            document.getElementById('response').style.display = "block";
        }
    };
    new Ajax.Updater('response','buscarAlmacen.action', options);
}

function ajaxListaAlmacenDet(){
    $('cargando').update("Cargando...");
    document.getElementById('response').style.display = "none";
    var options={
        method: 'get',
        parameters:{
        	titulo: document.getElementById('titulo').value,
        	codigo: document.getElementById('codigo').value,
        	isbn: document.getElementById('isbn').value,
        	editorial: document.getElementById('editorial').value,
        	categoria: document.getElementsByName('categoria').value,
        	//proveedor_id:  document.getElementById('proveedor_id').value,
        	autor:  document.getElementById('autor').value,
        	almacen_id :  document.getElementById('almacen_id').value,
        	codProveedor: document.getElementById('codProveedor').value,
        },
        onSuccess: function(){
            $('cargando').update("");
            document.getElementById('response').style.display = "block";
        }
    };
    new Ajax.Updater('response','buscarAlmacenDet.action', options);
}


function ajaxEliminarAlmacen(){
	if(obtenerEliminados()){
	    var options={
	        method: 'get',
	        parameters:{
	        	valoresEliminados: document.getElementById('valoresEliminados').value,
	        }
	    };
	    new Ajax.Updater('response','eliminarAlmacen.action', options);
    }
}

//REGISTRAR - MODIFICAR ALMACEN
function aceptarAlmacen_frmAlmacen(){
	document.frmAlmacen.method.value = "actualizar";
	document.frmAlmacen.submit();
}
function cancelarAlmacen_frmAlmacen(){
	document.frmAlmacen.method.value = "inicio";
	document.frmAlmacen.submit();
}

//FERIA ---------------------------------------------------------------------------
//BUSCAR FERIA
function nuevoFeria_frmFeria(){
	document.frmFeria.method.value = "nuevo";
	document.frmFeria.submit();
}

function modificarFeria_frmFeria(){
	if(obtenerSeleccionado()){
		document.frmFeria.method.value = "modificar";
		document.frmFeria.submit();
	}
}

function ajaxListaFeria(){
    $('cargando').update("Cargando...");
    document.getElementById('response').style.display = "none";
    var options={
        method: 'get',
        parameters:{
        	nombre: encodeURIComponent(document.getElementById('nombre').value),        	
        	fecha: document.getElementById('fecha').value,
        	direccion: encodeURIComponent(document.getElementById('direccion').value),
        	distrito: encodeURIComponent(document.getElementById('distrito').value),
        },
        onSuccess: function(){
            $('cargando').update("");
            document.getElementById('response').style.display = "block";
        }
    };
    new Ajax.Updater('response','buscarFeria.action', options);
}

function ajaxEliminarFeria(){
	if(obtenerEliminados()){
	    var options={
	        method: 'get',
	        parameters:{
	        	valoresEliminados: document.getElementById('valoresEliminados').value,
	        }
	    };
	    new Ajax.Updater('response','eliminarFeria.action', options);
    }
}

//REGISTRAR - MODIFICAR FERIA
function aceptarFeria_frmFeria(){
	document.frmFeria.method.value = "actualizar";
	document.frmFeria.submit();
}
function cancelarFeria_frmFeria(){
	document.frmFeria.method.value = "inicio";
	document.frmFeria.submit();
}

//PROVEEDOR ---------------------------------------------------------------------------
function seleccioneProveedor_frmDevolucion(){
	if(obtenerSeleccionado()){
		document.frmProveedor.method.value = "seleccionar";
		document.frmProveedor.submit();
	}
}

//BUSCAR PROVEEDOR
function nuevoProveedor_frmProveedor(){
	document.frmProveedor.method.value = "nuevo";
	document.frmProveedor.submit();
}

//REGISTRAR - MODIFICAR PROVEEDOR
function seleccione_proveedor(){
	var obj1 = document.getElementById("compra_id");
	var obj2 = document.getElementById("devolucion_id");
	var obj3 = document.getElementById("liquidacion_id");
	if (obj1 != null){
		window.open("proveedor.htm?method=listaProveedor&transaccion_id="+obj1.value , "ventana1" , "width=800,height=800,scrollbars=1,") 
	} else if (obj2 != null){
		window.open("proveedor.htm?method=listaProveedor&transaccion_id="+obj2.value , "ventana1" , "width=800,height=800,scrollbars=1") 
	} else if (obj3 != null){
		window.open("proveedor.htm?method=listaProveedor&transaccion_id="+obj3.value , "ventana1" , "width=800,height=800,scrollbars=1") 
	} else {
		window.open("proveedor.htm?method=listaProveedor" , "ventana1" , "width=800,height=800,scrollbars=1")
	}
}

function modificarProveedor_frmProveedor(){
	if(obtenerSeleccionado()){
		document.frmProveedor.method.value = "modificar";
		document.frmProveedor.submit();
	}
}

function consultarProveedor_frmProveedor(){
	if(obtenerSeleccionado()){
		document.frmProveedor.method.value = "consultar";
		document.frmProveedor.submit();
	}
}

function ajaxListaProveedor(){
    $('cargando').update("Cargando...");
    document.getElementById('response').style.display = "none";
    var options={
        method: 'get',
        parameters:{
        	nombres: encodeURIComponent(document.getElementById('nombres').value),
        	apepaterno: encodeURIComponent(document.getElementById('apepaterno').value),
        	apematerno: encodeURIComponent(document.getElementById('apematerno').value),
        	dni: document.getElementById('dni').value,
        	ruc: document.getElementById('ruc').value,        	
        },
        onSuccess: function(){
            $('cargando').update("");
            document.getElementById('response').style.display = "block";
        }
    };
    new Ajax.Updater('response','buscarProveedor.action', options);
}

function ajaxEliminarProveedor(){
	if(obtenerEliminados()){
	    var options={
	        method: 'get',
	        parameters:{
	        	valoresEliminados: document.getElementById('valoresEliminados').value,
	        }
	    };
	    new Ajax.Updater('response','eliminarProveedor.action', options);
    }
}

//REGISTRAR - MODIFICAR PROVEEDOR
function aceptarProveedor_frmProveedor(){
	document.frmProveedor.method.value = "actualizar";
	document.frmProveedor.submit();
}
function cancelarProveedor_frmProveedor(){
	document.frmProveedor.method.value = "inicio";
	document.frmProveedor.submit();
}

//CLIENTE ---------------------------------------------------------------------------
function seleccioneCliente_frmVenta(){
	if(obtenerSeleccionado()){
		document.frmCliente.method.value = "seleccionar";
		document.frmCliente.submit();
	}
}

//BUSCAR CLIENTE
function nuevoCliente_frmCliente(){
	document.frmCliente.method.value = "nuevo";
	document.frmCliente.submit();
}
//REGISTRAR - MODIFICAR CLIENTE
function seleccione_cliente(){
	var obj1 = document.getElementById("venta_id");	
	if (obj1 != null){
		window.open("cliente.htm?method=lista&transaccion_id="+obj1.value , "ventana1" , "width=800,height=800,scrollbars=NO")		 
	} else {
		window.open("cliente.htm?method=lista" , "ventana1" , "width=800,height=800,scrollbars=NO")
	}
}

function modificarCliente_frmCliente(){
	if(obtenerSeleccionado()){
		document.frmCliente.method.value = "modificar";
		document.frmCliente.submit();
	}
}

function ajaxListaCliente(){
    $('cargando').update("Cargando...");
    document.getElementById('response').style.display = "none";
    var options={
        method: 'get',
        parameters:{
        	nombres: encodeURIComponent(document.getElementById('nombres').value),
        	apepaterno: encodeURIComponent(document.getElementById('apepaterno').value),
        	apematerno: encodeURIComponent(document.getElementById('apematerno').value),
        	dni: document.getElementById('dni').value,
        	ruc: document.getElementById('ruc').value,   
        },
        onSuccess: function(){
            $('cargando').update("");
            document.getElementById('response').style.display = "block";
        }
    };
    new Ajax.Updater('response','buscarCliente.action', options);
}

function ajaxEliminarCliente(){
	if(obtenerEliminados()){
	    var options={
	        method: 'get',
	        parameters:{
	        	valoresEliminados: document.getElementById('valoresEliminados').value,
	        }
	    };
	    new Ajax.Updater('response','eliminarCliente.action', options);
    }
}

function aceptarCliente_frmCliente(){
	document.frmCliente.method.value = "actualizar";
	document.frmCliente.submit();
}
function cancelarCliente_frmCliente(){
	document.frmCliente.method.value = "inicio";
	document.frmCliente.submit();
}

//DOCUMENTODET ---------------------------------------------------------------------------

function ajaxAgregarDocumentoDet(){
    $('cargando').update("Cargando...");
    document.getElementById('response').style.display = "none";
    var options={
        method: 'get',
        parameters:{
        	documento_id: document.getElementById('documento_id').value,
        	codigoProducto: document.getElementById('codigoProducto').value,
        	isbnProducto: document.getElementById('isbnProducto').value,
        	cantidadProducto: document.getElementById('cantidadProducto').value,
        	precioUnitario: document.getElementById('precioUnitario').value,
        	porcDescuento: document.getElementById('porcDescuento').value,   
        },
        onSuccess: function(){
            $('cargando').update("");
            document.getElementById('response').style.display = "block";
        }
    };
    
    new Ajax.Updater('response','agregarDocumentoDet.action', options);
}

function ajaxAgregarArchivoDocumentoDet(){
    $('cargando').update("Cargando...");
    document.getElementById('response').style.display = "none";
    var options={
        method: 'get',
        parameters:{
        	upload: document.getElementsByName('upload').value,        	
        },
        onSuccess: function(){
            $('cargando').update("");
            document.getElementById('response').style.display = "block";
        }
    };
    
    new Ajax.Updater('response','agregarArchivoDocumentoDet.action', options);
}

function ajaxEliminarDocumentoDet(){
	if(obtenerEliminados()){
	    var options={
	        method: 'get',
	        parameters:{
	        	valoresEliminados: document.getElementById('valoresEliminados').value,
	        }
	    };
	    new Ajax.Updater('response','eliminarDocumentoDet.action', options);
    }
}


//VENTA ---------------------------------------------------------------------------
//BUSCAR VENTA
function nuevoVenta_frmVenta(){
	document.frmVenta.method.value = "nuevo";
	document.frmVenta.submit();
}
//REGISTRAR - MODIFICAR VENTA
function ajaxbuscaprecio(obj){
    var options={
        method: 'get',
        parameters:{
        	isbnProducto: obj.value 
        },
        onSuccess: function(){
        }
    };
    new Ajax.Updater('precio_response','buscaPrecio.action', options);
}
function ajaxbuscastock(obj){
    var options={
        method: 'get',
        parameters:{
        	cantidad: obj.value,
        	isbnProducto : document.getElementById('isbnProducto').value, 
        },
        onSuccess: function(){
        }
    };
    new Ajax.Updater('precio_response','buscaStock.action', options);
}
function consultarVenta_frmVenta(){
	if(obtenerSeleccionado()){
		document.frmVenta.method.value = "consultar";
		document.frmVenta.submit();
	}
}

function ajaxListaVenta(){
    $('cargando').update("Cargando...");
    document.getElementById('response').style.display = "none";
    var options={
        method: 'get',
        parameters:{
        	fechaini: document.getElementById('fechaini').value,
        	fechafin: document.getElementById('fechafin').value,
        	almacen_id: document.getElementById('almacenOrigen_id').value,
        	cliente_id: document.getElementById('cliente_id').value,   
        },
        onSuccess: function(){
            $('cargando').update("");
            document.getElementById('response').style.display = "block";
        }
    };
    new Ajax.Updater('response','buscarVenta.action', options);
}

function ajaxAnularVenta(){
	if(obtenerEliminados()){
	    var options={
	        method: 'get',
	        parameters:{
	        	valoresEliminados: document.getElementById('valoresEliminados').value,
	        }
	    };
	    new Ajax.Updater('response','anularVenta.action', options);
    }
}

function ajaxEliminarVenta(){
	if(obtenerEliminados()){
	    var options={
	        method: 'get',
	        parameters:{
	        	valoresEliminados: document.getElementById('valoresEliminados').value,
	        }
	    };
	    new Ajax.Updater('response','eliminarVenta.action', options);
    }
}

//REGISTRAR - MODIFICAR VENTA
function aceptarVenta_frmVenta(){
	document.frmVenta.method.value = "actualizar";
	document.frmVenta.submit();
}
function eliminarVenta_frmVenta(){
	document.frmVenta.method.value = "eliminar";
	document.frmVenta.submit();
}
function cancelarVenta_frmVenta(){
	document.frmVenta.method.value = "inicio";
	document.frmVenta.submit();
}

//DEVOLUCION ---------------------------------------------------------------------------
//BUSCAR DEVOLUCION
function nuevoDevolucion_frmDevolucion(){
	document.frmDevolucion.method.value = "nuevo";
	document.frmDevolucion.submit();
}
//REGISTRAR - MODIFICAR DEVOLUCION
function ajaxbuscaprecioDevolucion(obj){
    var options={
        method: 'get',
        parameters:{
        	isbnProducto: obj.value 
        },
        onSuccess: function(){
        }
    };
    new Ajax.Updater('precio_response','buscaPrecioDevolucion.action', options);
}
function ajaxbuscastockDevolucion(obj){
    var options={
        method: 'get',
        parameters:{
        	cantidad: obj.value,
        	isbnProducto : document.getElementById('isbnProducto').value, 
        },
        onSuccess: function(){
        }
    };
    new Ajax.Updater('precio_response','buscaStockDevolucion.action', options);
}
function consultarDevolucion_frmDevolucion(){
	if(obtenerSeleccionado()){
		document.frmDevolucion.method.value = "consultar";
		document.frmDevolucion.submit();
	}
}

function ajaxListaDevolucion(){
    $('cargando').update("Cargando...");
    document.getElementById('response').style.display = "none";    
    var options={
        method: 'get',
        parameters:{
        	fechaini: document.getElementById('fechaini').value,
        	fechafin: document.getElementById('fechafin').value,
        	almacen_id: document.getElementById('almacenOrigen_id').value,
        	proveedor_id: document.getElementById('proveedor_id').value,   
        },
        onSuccess: function(){
            $('cargando').update("");
            document.getElementById('response').style.display = "block";
        }
    };
    new Ajax.Updater('response','buscarDevolucion.action', options);
}

function ajaxAnularDevolucion(){
	if(obtenerEliminados()){
	    var options={
	        method: 'get',
	        parameters:{
	        	valoresEliminados: document.getElementById('valoresEliminados').value,
	        }
	    };
	    new Ajax.Updater('response','anularDevolucion.action', options);
    }
}

function ajaxEliminarDevolucion(){
	if(obtenerEliminados()){
	    var options={
	        method: 'get',
	        parameters:{
	        	valoresEliminados: document.getElementById('valoresEliminados').value,
	        }
	    };
	    new Ajax.Updater('response','eliminarDevolucion.action', options);
    }
}

//REGISTRAR - MODIFICAR DEVOLUCION
function aceptarDevolucion_frmDevolucion(){
	document.frmDevolucion.method.value = "actualizar";
	document.frmDevolucion.submit();
}
function eliminarDevolucion_frmDevolucion(){
	document.frmDevolucion.method.value = "eliminar";
	document.frmDevolucion.submit();
}
function cancelarDevolucion_frmDevolucion(){
	document.frmDevolucion.method.value = "inicio";
	document.frmDevolucion.submit();
}


//COMPRA ---------------------------------------------------------------------------
//BUSCAR COMPRA
function nuevoCompra_frmCompra(){
	document.frmCompra.method.value = "nuevo";
	document.frmCompra.submit();
}
function importarCompra_frmCompra(){
	document.frmCompra.method.value = "importar";
	document.frmCompra.submit();
}
function agregarCompra_frmCompra(){
	document.frmCompra.method.value = "agregar";
	document.frmCompra.submit();
}
//REGISTRAR - MODIFICAR COMPRA
function seleccione_frmCompra(){
	document.forms[0].method.value = "agregarArchivoDocumentoDet";
	document.forms[0].submit();
}
function importarCompraAuxiliar_frmCompra(){
	var obj1 = document.getElementById("compra_id");
	var obj2 = document.getElementById("proveedor");
	var obj3 = document.getElementById("proveedor_id");	
	if (obj1 != null && obj2 != null && obj3 != null){		
		window.open("agregarArchivoDocumentoDet.action?documento_id="+document.getElementById('documento_id').value+"&transaccion_id="+obj1.value+"&proveedor="+obj2.value+"&proveedor_id="+obj3.value , "ventana1" , "width=800,height=800,scrollbars=1,resizable=1")
	} else if (obj1 != null){		
		window.open("agregarArchivoDocumentoDet.action?documento_id="+document.getElementById('documento_id').value+"&transaccion_id="+obj1.value , "ventana1" , "width=800,height=800,scrollbars=1,resizable=1")	 
	} else {
		window.open("agregarArchivoDocumentoDet.action?documento_id="+document.getElementById('documento_id').value , "ventana1" , "width=800,height=800,scrollbars=1,resizable=1")
	}


	 
}
function ajaxbuscaprecioCompra(obj){
    var options={
        method: 'get',
        parameters:{
        	isbnProducto: obj.value 
        },
        onSuccess: function(){
        }
    };
    new Ajax.Updater('precio_response','buscaPrecioCompra.action', options);
}
function consultarCompra_frmCompra(){
	if(obtenerSeleccionado()){
		document.frmCompra.method.value = "consultar";
		document.frmCompra.submit();
	}
}

function ajaxListaCompra(){
    $('cargando').update("Cargando...");
    document.getElementById('response').style.display = "none";
    var options={
        method: 'get',
        parameters:{
        	fechaini: document.getElementById('fechaini').value,
        	fechafin: document.getElementById('fechafin').value,
        	almacen_id: document.getElementById('almacenOrigen_id').value,
        	proveedor_id: document.getElementById('proveedor_id').value,
        	tipocompra: document.getElementById('tipocompra').value,
        },
        onSuccess: function(){
            $('cargando').update("");
            document.getElementById('response').style.display = "block";
        }
    };
    new Ajax.Updater('response','buscarCompra.action', options);
}

function ajaxAnularCompra(){
	if(obtenerEliminados()){
	    var options={
	        method: 'get',
	        parameters:{
	        	valoresEliminados: document.getElementById('valoresEliminados').value,
	        }
	    };
	    new Ajax.Updater('response','anularCompra.action', options);
    }
}

function ajaxEliminarCompra(){
	if(obtenerEliminados()){
	    var options={
	        method: 'get',
	        parameters:{
	        	valoresEliminados: document.getElementById('valoresEliminados').value,
	        }
	    };
	    new Ajax.Updater('response','eliminarCompra.action', options);
    }
}

//REGISTRAR - MODIFICAR COMPRA
function aceptarCompra_frmCompra(){
	document.frmCompra.method.value = "actualizar";
	document.frmCompra.submit();
}
function aceptarImportarCompra_frmCompra(){
	document.frmCompra.method.value = "actualizarImportar";
	document.frmCompra.submit();
}
function eliminarCompra_frmCompra(){
	document.frmCompra.method.value = "eliminar";
	document.frmCompra.submit();
}
function cancelarCompra_frmCompra(){
	document.frmCompra.method.value = "inicio";
	document.frmCompra.submit();
}

//LIQUIDACION ---------------------------------------------------------------------------
function nuevoLiquidacion_frmLiquidacion(){
	document.frmLiquidacion.method.value = "nuevo";
	document.frmLiquidacion.submit();
}
function agregarLiquidacion_frmLiquidacion(){
	document.frmLiquidacion.method.value = "agregar";
	document.frmLiquidacion.submit();
}

function ajaxbuscaprecioLiquidacion(obj){
    var options={
        method: 'get',
        parameters:{
        	isbnProducto: obj.value 
        },
        onSuccess: function(){
        }
    };
    new Ajax.Updater('precio_response','buscaPrecioLiquidacion.action', options);
    
    var options={
        method: 'get',
        parameters:{
        	isbnProducto: obj.value 
        },
        onSuccess: function(){
        }
    };
    new Ajax.Updater('liquidar','buscaMontosLiquidacion.action', options);
}
function consultarLiquidacion_frmLiquidacion(){
	if(obtenerSeleccionado()){
		document.frmLiquidacion.method.value = "consultar";
		document.frmLiquidacion.submit();
	}
}

function ajaxListaLiquidacion(){
    $('cargando').update("Cargando...");
    document.getElementById('response').style.display = "none";
    var options={
        method: 'get',
        parameters:{
        	fechaini: document.getElementById('fechaini').value,
        	fechafin: document.getElementById('fechafin').value,        	
        	proveedor_id: document.getElementById('proveedor_id').value,        	
        },
        onSuccess: function(){
            $('cargando').update("");
            document.getElementById('response').style.display = "block";
        }
    };
    new Ajax.Updater('response','buscarLiquidacion.action', options);
}

function ajaxEliminarLiquidacion(){
	if(obtenerEliminados()){
	    var options={
	        method: 'get',
	        parameters:{
	        	valoresEliminados: document.getElementById('valoresEliminados').value,
	        }
	    };
	    new Ajax.Updater('response','eliminarLiquidacion.action', options);
    }
}

//REGISTRAR - MODIFICAR LIQUIDACION
function aceptarLiquidacion_frmLiquidacion(){
	document.frmLiquidacion.method.value = "actualizar";
	document.frmLiquidacion.submit();
}
function eliminarLiquidacion_frmLiquidacion(){
	document.frmLiquidacion.method.value = "eliminar";
	document.frmLiquidacion.submit();
}
function cancelarLiquidacion_frmLiquidacion(){
	document.frmLiquidacion.method.value = "inicio";
	document.frmLiquidacion.submit();
}

//MOVIMIENTO ---------------------------------------------------------------------------
//BUSCAR MOVIMIENTO
function nuevoMovimiento_frmMovimiento(){
	document.frmMovimiento.method.value = "nuevo";
	document.frmMovimiento.submit();
}

function ajaxListaMovimiento(){
    $('cargando').update("Cargando...");
    document.getElementById('response').style.display = "none";
    var options={
        method: 'get',
        parameters:{        	
        	almacenOrigen_id: document.getElementById('almacenOrigen_id').value,
        	almacenDestino_id: document.getElementById('almacenDestino_id').value,
        	fechaSalida: document.getElementById('fechaSalida').value,
        	fechaLlegada: document.getElementById('fechaLlegada').value,
        	isbn: document.getElementById('isbn').value,   
        },
        onSuccess: function(){
            $('cargando').update("");
            document.getElementById('response').style.display = "block";
        }
    };
    new Ajax.Updater('response','buscarMovimiento.action', options);
}

function ajaxAgregarMovimiento(){
    $('cargando').update("Cargando...");
    document.getElementById('response').style.display = "none";
    var options={
        method: 'get',
        parameters:{
        	almacenOrigen_id: document.getElementById('almacenOrigen_id').value,
        	almacenDestino_id: document.getElementById('almacenDestino_id').value,
        	fechaSalida: document.getElementById('fechaSalida').value,
        	fechaLlegada: document.getElementById('fechaLlegada').value,
        	isbnProducto: document.getElementById('isbnProducto').value,
        	cantidad: document.getElementById('cantidad').value,   
        },
        onSuccess: function(){
            $('cargando').update("");
            document.getElementById('response').style.display = "block";
        }
    };
    
    new Ajax.Updater('response','agregarMovimiento.action', options);
}


//REGISTRAR - MODIFICAR MOVIMIENTO
function aceptarMovimiento_frmMovimiento(){
	document.frmMovimiento.method.value = "actualizar";
	document.frmMovimiento.submit();
}
function cancelarMovimiento_frmMovimiento(){
	document.frmMovimiento.method.value = "inicio";
	document.frmMovimiento.submit();
}