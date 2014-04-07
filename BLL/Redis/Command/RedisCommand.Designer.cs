﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.269
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RedisManagementStudio.BLL.Redis.Command {
    using System;
    
    
    /// <summary>
    ///   Une classe de ressource fortement typée destinée, entre autres, à la consultation des chaînes localisées.
    /// </summary>
    // Cette classe a été générée automatiquement par la classe StronglyTypedResourceBuilder
    // à l'aide d'un outil, tel que ResGen ou Visual Studio.
    // Pour ajouter ou supprimer un membre, modifiez votre fichier .ResX, puis réexécutez ResGen
    // avec l'option /str ou régénérez votre projet VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal partial class RedisCommand {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal RedisCommand() {
        }
        
        /// <summary>
        ///   Retourne l'instance ResourceManager mise en cache utilisée par cette classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("RedisManagementStudio.BLL.Redis.Command.RedisCommand", typeof(RedisCommand).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Remplace la propriété CurrentUICulture du thread actuel pour toutes
        ///   les recherches de ressources à l'aide de cette classe de ressource fortement typée.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Reinitialise la liste des commandes les plus lentes.
        /// </summary>
        internal static string commandreset {
            get {
                return ResourceManager.GetString("commandreset", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Affiche les commandes les plus lentes.
        /// </summary>
        internal static string commandshow {
            get {
                return ResourceManager.GetString("commandshow", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Réinitialise les statistiques rapportées par la commande INFO de Redis.
        ///
        ///Les compteurs sont les suivant :
        /// • Visties des clés
        /// • clé non trouvées
        /// • Nombre de commandes traitées
        /// • Nombre de connexions reçues
        /// • Nombre de clés expirées
        /// • Nombre de connexions rejetées
        /// • Dernièr fork
        /// • Le compteur aof_delayed_fsync.
        /// </summary>
        internal static string configresestatTips {
            get {
                return ResourceManager.GetString("configresestatTips", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Etes vous certain de vouloir réinitialiser les statistiques du serveur ?.
        /// </summary>
        internal static string configresetstatQuestion {
            get {
                return ResourceManager.GetString("configresetstatQuestion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Erreur lors de la renitialisation des statistiques :.
        /// </summary>
        internal static string configresetstatRKo {
            get {
                return ResourceManager.GetString("configresetstatRKo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Statistiques renitialisées avec succès.
        /// </summary>
        internal static string configresetstatROk {
            get {
                return ResourceManager.GetString("configresetstatROk", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Lancer une sauvegarde (snapshoot) asynchrone sur le serveur.
        /// </summary>
        internal static string persistancebgsave {
            get {
                return ResourceManager.GetString("persistancebgsave", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Lancer une sauvegarde différentielle en tâche de fond.
        /// </summary>
        internal static string persistancebtbgrewriteaof {
            get {
                return ResourceManager.GetString("persistancebtbgrewriteaof", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Lancer une sauvegarde synchrone sur le serveur.
        /// </summary>
        internal static string persistancesave {
            get {
                return ResourceManager.GetString("persistancesave", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Confirmez.
        /// </summary>
        internal static string TitleConfirm {
            get {
                return ResourceManager.GetString("TitleConfirm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Echec d&apos;une opération.
        /// </summary>
        internal static string TitleError {
            get {
                return ResourceManager.GetString("TitleError", resourceCulture);
            }
        }
    }
}