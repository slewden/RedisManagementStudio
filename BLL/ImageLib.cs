using System.ComponentModel;

namespace RedisManagementStudio.BLL
{
  /// <summary>
  /// Gestion des images de l'application (hors ressources)
  /// </summary>
  public partial class ImageLib : Component
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="ImageLib" />.
    /// </summary>
    public ImageLib()
    {
      this.InitializeComponent();
    }

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="ImageLib" />.
    /// </summary>
    /// <param name="container">Le conteneur</param>
    public ImageLib(IContainer container)
    {
      container.Add(this);

      this.InitializeComponent();
    }
  }
}
