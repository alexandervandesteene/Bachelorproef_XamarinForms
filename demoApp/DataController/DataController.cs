using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Net;

namespace demoApp
{
	public class DataController
	{
		/*public async static Task<JObject> maakverbinding(string page)
		{
			// ... Use HttpClient.
			HttpClient client = new HttpClient();

			using (HttpResponseMessage response = await client.GetAsync(page))
			using (HttpContent content = response.Content)
			{
				// ... Read the string.
				string result = await content.ReadAsStringAsync();
				// System.Runtime.Serialization.Json
				JObject JsonDe = JObject.Parse(result);

				return JsonDe;
			}
		}*/


		/*public static async Task<List<User>> GetAllUsers() {
			// ... Target page.
			string page = "http://phpapialex.azurewebsites.net/getContacts.php";

			JObject JsonDe = await maakverbinding(page);
		
			IList<JToken> results = JsonDe.Children().ToList();
			List<User> lijstje = new List<User>();
			foreach (JToken resul in results) {
				//Content fgfgt = (Content)((Object)results.ToString());
				User ctn = JsonConvert.DeserializeObject<User>(resul.ToString());
				lijstje.Add(ctn);
			}
			return lijstje;
		}*/

		public static async Task<List<User>> getUsersAsync() 
		{ 
			var httpClient = new HttpClient(); 

			try 
			{ 
				var jsonResponse = await httpClient.GetStringAsync("http://phpapialex.azurewebsites.net/getContacts.php"); 

				var userList = await JsonConvert.DeserializeObjectAsync<List<User>>(jsonResponse); 

				return userList;   
			} 
			catch(Exception exc) 
			{ 
				System.Diagnostics.Debug.WriteLine (exc);
			} 

			return null; 
		} 

	public static async Task<User> getUserAsync(string id) 
	{ 
		var httpClient = new HttpClient();

			String url = "http://phpapialex.azurewebsites.net/getContact.php?id=" + id;

		try 
		{ 
			var jsonResponse = await httpClient.GetStringAsync(url); 
		
			var userList = await JsonConvert.DeserializeObjectAsync<List<User>>(jsonResponse); 

			var user = userList[0];

			return user;   
		} 
		catch(Exception exc) 
		{ 
			System.Diagnostics.Debug.WriteLine (exc);
		} 
		return null; 
	} 

	public static async Task<Boolean> removeUser(string id) 
	{ 
		var httpClient = new HttpClient();

		try 
		{ 
			var jsonRequest = new {id = id};
			var serializedJsonRequest = JsonConvert.SerializeObject (jsonRequest);
			HttpContent content = new StringContent (serializedJsonRequest, Encoding.UTF8, "application/json");

			var response = await httpClient.PostAsync ("http://phpapialex.azurewebsites.net/verwijderContact.php", content);

			if(response.IsSuccessStatusCode){
				var result = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);                                                                        
				return true;
			}
			
		} 
		catch(Exception exc) 
		{ 
			System.Diagnostics.Debug.WriteLine (exc);

		} 
		return false; 
	} 


	public static async Task<Boolean> updateUser(string id,string fristname,string lastname,string email,string gender,string ipadress) 
	{ 
		var httpClient = new HttpClient();

		try 
		{ 
			var jsonRequest = new {id = id,first_name = fristname,last_name =lastname,email=email,gender=gender,ip_address=ipadress};
			var serializedJsonRequest = JsonConvert.SerializeObject (jsonRequest);
			HttpContent content = new StringContent (serializedJsonRequest, Encoding.UTF8, "application/json");

			var response = await httpClient.PostAsync ("http://phpapialex.azurewebsites.net/updateContact.php", content);

			if(response.IsSuccessStatusCode){
				var result = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);                                                                        
				return true;
			}

		} 
		catch(Exception exc) 
		{ 
			System.Diagnostics.Debug.WriteLine (exc);

		} 
		return false; 
	} 

	public static async Task<Boolean> addUser(string fristname,string lastname,string email,string gender,string ipadress) 
	{ 
		var httpClient = new HttpClient();

		try 
		{ 
			var jsonRequest = new {first_name = fristname,last_name =lastname,email=email,gender=gender,ip_address=ipadress};
			var serializedJsonRequest = JsonConvert.SerializeObject (jsonRequest);
			HttpContent content = new StringContent (serializedJsonRequest, Encoding.UTF8, "application/json");

			var response = await httpClient.PostAsync ("http://phpapialex.azurewebsites.net/addContact.php", content);

			if(response.IsSuccessStatusCode){
				var result = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);                                                                        
				return true;
			}

		} 
		catch(Exception exc) 
		{ 
			System.Diagnostics.Debug.WriteLine (exc);

		} 
		return false; 
	} 




	}
}

