using Icarus.Logic.Patterns;

namespace Icarus.Logic.Offsets
{
    internal interface IOffset
    {
        int Build { get; }

        /// <summary>
        /// CWorld::Enables
        /// Hint: "Detail doodads enabled."
        /// </summary>
        int WorldEnables { get; }

        /// <summary>
        /// CGWorldFrame::s_currentWorldFrame
        /// </summary>
        int CurWorldFrame { get; }

        /// <summary>
        /// CGWorldFrame::s_currentWorldFrame->m_camera
        /// <para>Hint: "s_currentWorldFrame->m_camera" or "Camera FREELOOK" parent</para>
        /// </summary>
        int CameraOffset { get; }

        /// <summary>
        /// Offset to the camera object's fields
        /// </summary>
        int CameraFieldOffset { get; }

        /// <summary>
        /// CGCamera::CalcThirdPerson
        /// <para>Hint: "cameraDist >= 0.0f"</para>
        /// </summary>
        Pattern CalcThirdPerson { get; }

        /// <summary>
        /// CWorldParam::FarClipCallback
        /// </summary>
        Pattern SetFarclipPattern { get; }
    }
}