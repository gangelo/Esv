using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;



namespace Esv {
	internal class EsvServer {
		static private object m_synchRoot = new object();

		public EsvServer() {
		}

		static public bool GetReference(string reference, out string passage, out string errorMessage) {
			lock (m_synchRoot) {
				passage = string.Empty;
				errorMessage = string.Empty;

				StringBuilder urlBuilder = new StringBuilder();
				urlBuilder.Append("http://www.esvapi.org/v2/rest/passageQuery");
				urlBuilder.Append("?key=IP");
				urlBuilder.Append("&passage=" + System.Uri.EscapeDataString(reference));
				urlBuilder.Append("&output-format=plain-text");				

				try {
					try {
						WebRequest webRequest = WebRequest.Create(urlBuilder.ToString());
						using (StreamReader streamReader = new StreamReader(webRequest.GetResponse().GetResponseStream())) {
							StringBuilder passageBuilder = new StringBuilder();
							passageBuilder.Append(streamReader.ReadToEnd());
							passage = passageBuilder.ToString();
						}
						return true;
					} catch (Exception e) {
						errorMessage = e.Message;
						return false;
					}
				} finally {
				}
			}
		}
	};
};
