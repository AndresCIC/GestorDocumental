<template>
	<div id="Master" class="master-div">		
		<table class="table">
			<thead>
				<tr>
					<th>#</th>
					<th>First Name</th>
					<th>
						<th>
							<th> <i class="fa fa-user-plus" aria-hidden="true" v-on:click="newDetail()"></i></th>
						</tr>
					</thead>			 
					<tbody v-for="(item, index) in lista">
						<tr>
							<th scope="row" v-model='index'>{{index}}</th>
							<td>{{item.Nombre}}</td>			      
							<td>
								<i class="fa fa-book" aria-hidden="true" v-on:click="readDetail(item.Id)"></i>
							</td>
							<td>
								<i class="fa fa-pencil-square" aria-hidden="true" v-on:click="updateDetail(item.Id)"></i>
							</td>
							<td>
								<i class="fa fa-trash" aria-hidden="true" v-on:click="deleteItem(item.Id)" ></i>					
							</td>
						</tr>
					</tbody>			    
				</table>
			</div>
		</template>

<script>
	export default{
		components:{
		},
		data (){
			return{
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

<style></style>