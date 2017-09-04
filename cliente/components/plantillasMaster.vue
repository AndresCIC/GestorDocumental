<template>
<table class="table">
		<table class="table table-hover">
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

						<tr >

							<th scope="row" v-model='index'>{{index}}</th>
							<td>{{item.Titulo}}</td>
							<td>{{item.Titulo}}</td>
							<td>{{item.Tipo}}</td>
							<td>{{item.SoloLectura}}</td>		

						</tr>
					</tbody>			    
				</table>
			</div>	    
</table>
</template>
<script type="text/javascript">
	export default{
		name: "Plantillas",
		components:{
		},
		data (){
			return{
				lista: []
			}
		},
		computed:{

		},
		methods:{
			emitEnableDetailEvent(read) {
		      // Send the event on a channel () with a payload ()
		      EventBus.$emit('enableDetail', this.read);
			},
			newDetail: function(index){
				this.read= false;
				this.emitEnableDetailEvent(this.read);
			},			
		}
	}

</script>
<style type="text/css"></style>