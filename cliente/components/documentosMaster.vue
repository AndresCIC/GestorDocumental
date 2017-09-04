<template>
	<div id="documentosMaster">
		<table class="table">
				<table class="table table-hover" role="tablist">
					<thead>
						<tr>
							<th>#</th>
							<th>Título</th>
							<th>Última modificación</th>
								<th>Tipo</th>
								<th>Solo lectura</th>
									<th> <a href=""> <i class="fa fa-user-plus" aria-hidden="true" v-on:click="newDetail()"></i> </a></th>
						</tr>
							</thead>			 
							<tbody @click="" v-for="(item, index) in lista">

								<tr v-on:click="renderDetail(item)">
									<th scope="row" v-model='index'>{{index}}</th>
									<td>{{item.Titulo}}</td>
									<td>{{item.Titulo}}</td>
									<td>{{item.Tipo}}</td>
									<td>{{item.SoloLectura}}</td>
									
								</tr>
								<tr  v-if="showDetail">
									<td colspan="6">
										<detail role="tabpanel" class="float-right"> </detail>
									</td>
								</tr>
							</tbody>			    

						</table>
			
		</table>
	</div>
</template>
<script type="text/javascript">
import constantes from './constants.js';
import detail from './detail.vue'
	export default{
		name: "Documentos",
		components:{
			detail,
		},
		data (){
			return{
				lista: [],
				menuChoice:"Documentos",
				showDetail: false,

			}
		},
		computed:{

		},
		methods:{
			makeGetListRequest(){
				$.ajax({
					url: constantes.BASE_URL + this.menuChoice,
					method: "GET"
				})
				.done(this.submitGetListValues)
				.fail(function(){
					alert("Ha fallado la carga del objeto");
				})
			},
			submitGetListValues: function(datos){
				this.lista = datos;
			},
			emitEnableDetailEvent(read) {
		      // Send the event on a channel () with a payload ()
		      EventBus.$emit('enableDetail', this.read);
			},
			newDetail: function(index){
				this.read= false;
				this.emitEnableDetailEvent(this.read);
			},	
			readDetail: function(){
				
			},
			renderDetail: function(documento){
				this.showDetail == false ? this.showDetail = true :  this.showDetail = false;

			},		
		},
		created(){
			this.makeGetListRequest();
		},
	}
</script>
<style type="text/css"></style>