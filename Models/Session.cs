using Newtonsoft.Json;
using InfluxDB.Client.Core;

namespace ArrExporter.Models
{
    /// <summary>
    /// Model for the get_activity-command.
    /// The model represents the 'sessions' object in the response.
    /// </summary>
    /// <seealso href="https://github.com/Tautulli/Tautulli/wiki/Tautulli-API-Reference#get_activity" />
    [Measurement("session")]
    public class Session
    {
        [JsonProperty("added_at")]
		[Column("added_at", IsTag = true)]
		public string AddedAt { get; set; } = default!;

		[JsonProperty("allow_guest")]
		[Column("allow_guest", IsTag = true)]
		public int AllowGuest { get; set; } = default!;

		[JsonProperty("art")]
		[Column("art", IsTag = true)]
		public string Art { get; set; } = default!;

		[JsonProperty("aspect_ratio")]
		[Column("aspect_ratio", IsTag = true)]
		public string AspectRatio { get; set; } = default!;

		[JsonProperty("audience_rating")]
		[Column("audience_rating", IsTag = true)]
		public string AudienceRating { get; set; } = default!;

		[JsonProperty("audience_rating_image")]
		[Column("audience_rating_image", IsTag = true)]
		public string AudienceRatingImage { get; set; } = default!;

		[JsonProperty("audio_bitrate")]
		[Column("audio_bitrate", IsTag = true)]
		public string AudioBitrate { get; set; } = default!;

		[JsonProperty("audio_bitrate_mode")]
		[Column("audio_bitrate_mode", IsTag = true)]
		public string AudioBitrateMode { get; set; } = default!;

		[JsonProperty("audio_channel_layout")]
		[Column("audio_channel_layout", IsTag = true)]
		public string AudioChannelLayout { get; set; } = default!;

		[JsonProperty("audio_channels")]
		[Column("audio_channels", IsTag = true)]
		public string AudioChannels { get; set; } = default!;

		[JsonProperty("audio_codec")]
		[Column("audio_codec", IsTag = true)]
		public string AudioCodec { get; set; } = default!;

		[JsonProperty("audio_decision")]
		[Column("audio_decision", IsTag = true)]
		public string AudioDecision { get; set; } = default!;

		[JsonProperty("audio_language")]
		[Column("audio_language", IsTag = true)]
		public string AudioLanguage { get; set; } = default!;

		[JsonProperty("audio_language_code")]
		[Column("audio_language_code", IsTag = true)]
		public string AudioLanguageCode { get; set; } = default!;

		[JsonProperty("audio_profile")]
		[Column("audio_profile", IsTag = true)]
		public string AudioProfile { get; set; } = default!;

		[JsonProperty("audio_sample_rate")]
		[Column("audio_sample_rate", IsTag = true)]
		public string AudioSampleRate { get; set; } = default!;

		[JsonProperty("bandwidth")]
		[Column("bandwidth", IsTag = true)]
		public string Bandwidth { get; set; } = default!;

		[JsonProperty("banner")]
		[Column("banner", IsTag = true)]
		public string Banner { get; set; } = default!;

		[JsonProperty("bitrate")]
		[Column("bitrate", IsTag = true)]
		public string Bitrate { get; set; } = default!;

		[JsonProperty("channel_call_sign")]
		[Column("channel_call_sign", IsTag = true)]
		public string ChannelCallSign { get; set; } = default!;

		[JsonProperty("channel_identifier")]
		[Column("channel_identifier", IsTag = true)]
		public string ChannelIdentifier { get; set; } = default!;

		[JsonProperty("channel_stream")]
		[Column("channel_stream", IsTag = true)]
		public int ChannelStream { get; set; } = default!;

		[JsonProperty("children_count")]
		[Column("children_count", IsTag = true)]
		public int ChildrenCount { get; set; } = default!;

		[JsonProperty("container")]
		[Column("container", IsTag = true)]
		public string Container { get; set; } = default!;

		[JsonProperty("container_decision")]
		[Column("container_decision", IsTag = true)]
		public string ContainerDecision { get; set; } = default!;

		[JsonProperty("content_rating")]
		[Column("content_rating", IsTag = true)]
		public string ContentRating { get; set; } = default!;

		[JsonProperty("deleted_user")]
		[Column("deleted_user", IsTag = true)]
		public int DeletedUser { get; set; } = default!;

		[JsonProperty("device")]
		[Column("device", IsTag = true)]
		public string Device { get; set; } = default!;

		[JsonProperty("do_notify")]
		[Column("do_notify", IsTag = true)]
		public int DoNotify { get; set; } = default!;

		[JsonProperty("duration")]
		[Column("duration", IsTag = true)]
		public string Duration { get; set; } = default!;

		[JsonProperty("edition_title")]
		[Column("edition_title", IsTag = true)]
		public string EditionTitle { get; set; } = default!;

		[JsonProperty("email")]
		[Column("email", IsTag = true)]
		public string Email { get; set; } = default!;

		[JsonProperty("file")]
		[Column("file", IsTag = true)]
		public string File { get; set; } = default!;

		[JsonProperty("file_size")]
		[Column("file_size", IsTag = true)]
		public string FileSize { get; set; } = default!;

		[JsonProperty("friendly_name")]
		[Column("friendly_name", IsTag = true)]
		public string FriendlyName { get; set; } = default!;

		[JsonProperty("full_title")]
		[Column("full_title", IsTag = true)]
		public string FullTitle { get; set; } = default!;

		[JsonProperty("grandparent_title")]
		[Column("grandparent_title", IsTag = true)]
		public string GrandparentTitle { get; set; } = default!;

		[JsonProperty("grandparent_year")]
		[Column("grandparent_year", IsTag = true)]
		public string GrandparentYear { get; set; } = default!;

		[JsonProperty("height")]
		[Column("height", IsTag = true)]
		public string Height { get; set; } = default!;

		[JsonProperty("ip_address")]
		[Column("ip_address", IsTag = true)]
		public string IpAddress { get; set; } = default!;

		[JsonProperty("ip_address_public")]
		[Column("ip_address_public", IsTag = true)]
		public string IpAddressPublic { get; set; } = default!;

		[JsonProperty("is_active")]
		[Column("is_active", IsTag = true)]
		public int IsActive { get; set; } = default!;

		[JsonProperty("is_admin")]
		[Column("is_admin", IsTag = true)]
		public int IsAdmin { get; set; } = default!;

		[JsonProperty("is_allow_sync")]
		[Column("is_allow_sync", IsTag = true)]
		public int IsAllowSync { get; set; } = default!;

		[JsonProperty("is_home_user")]
		[Column("is_home_user", IsTag = true)]
		public int IsHomeUser { get; set; } = default!;

		[JsonProperty("is_restricted")]
		[Column("is_restricted", IsTag = true)]
		public int IsRestricted { get; set; } = default!;

		[JsonProperty("keep_history")]
		[Column("keep_history", IsTag = true)]
		public int KeepHistory { get; set; } = default!;

		[JsonProperty("last_seen")]
		[Column("last_seen", IsTag = true)]
		public string LastSeen { get; set; } = default!;

		[JsonProperty("last_viewed_at")]
		[Column("last_viewed_at", IsTag = true)]
		public string LastViewedAt { get; set; } = default!;

		[JsonProperty("library_name")]
		[Column("library_name", IsTag = true)]
		public string LibraryName { get; set; } = default!;

		[JsonProperty("live")]
		[Column("live", IsTag = true)]
		public int Live { get; set; } = default!;

		[JsonProperty("live_uuid")]
		[Column("live_uuid", IsTag = true)]
		public string LiveUuid { get; set; } = default!;

		[JsonProperty("local")]
		[Column("local", IsTag = true)]
		public int Local { get; set; } = default!;

		[JsonProperty("location")]
		[Column("location", IsTag = true)]
		public string Location { get; set; } = default!;

		[JsonProperty("machine_id")]
		[Column("machine_id", IsTag = true)]
		public string MachineId { get; set; } = default!;

		[JsonProperty("media_index")]
		[Column("media_index", IsTag = true)]
		public string MediaIndex { get; set; } = default!;

		[JsonProperty("media_type")]
		[Column("media_type", IsTag = true)]
		public string MediaType { get; set; } = default!;

		[JsonProperty("optimized_version")]
		[Column("optimized_version", IsTag = true)]
		public int OptimizedVersion { get; set; } = default!;

		[JsonProperty("optimized_version_profile")]
		[Column("optimized_version_profile", IsTag = true)]
		public string OptimizedVersionProfile { get; set; } = default!;

		[JsonProperty("optimized_version_title")]
		[Column("optimized_version_title", IsTag = true)]
		public string OptimizedVersionTitle { get; set; } = default!;

		[JsonProperty("original_title")]
		[Column("original_title", IsTag = true)]
		public string OriginalTitle { get; set; } = default!;

		[JsonProperty("originally_available_at")]
		[Column("originally_available_at", IsTag = true)]
		public string OriginallyAvailableAt { get; set; } = default!;

		[JsonProperty("parent_media_index")]
		[Column("parent_media_index", IsTag = true)]
		public string ParentMediaIndex { get; set; } = default!;

		[JsonProperty("parent_title")]
		[Column("parent_title", IsTag = true)]
		public string ParentTitle { get; set; } = default!;

		[JsonProperty("parent_year")]
		[Column("parent_year", IsTag = true)]
		public string ParentYear { get; set; } = default!;

		[JsonProperty("platform")]
		[Column("platform", IsTag = true)]
		public string Platform { get; set; } = default!;

		[JsonProperty("platform_name")]
		[Column("platform_name", IsTag = true)]
		public string PlatformName { get; set; } = default!;

		[JsonProperty("platform_version")]
		[Column("platform_version", IsTag = true)]
		public string PlatformVersion { get; set; } = default!;

		[JsonProperty("player")]
		[Column("player", IsTag = true)]
		public string Player { get; set; } = default!;

		[JsonProperty("product")]
		[Column("product", IsTag = true)]
		public string Product { get; set; } = default!;

		[JsonProperty("product_version")]
		[Column("product_version", IsTag = true)]
		public string ProductVersion { get; set; } = default!;

		[JsonProperty("profile")]
		[Column("profile", IsTag = true)]
		public string Profile { get; set; } = default!;

		[JsonProperty("progress_percent")]
		[Column("progress_percent", IsTag = true)]
		public string ProgressPercent { get; set; } = default!;

		[JsonProperty("quality_profile")]
		[Column("quality_profile", IsTag = true)]
		public string QualityProfile { get; set; } = default!;

		[JsonProperty("rating")]
		[Column("rating", IsTag = true)]
		public string Rating { get; set; } = default!;

		[JsonProperty("rating_image")]
		[Column("rating_image", IsTag = true)]
		public string RatingImage { get; set; } = default!;

		[JsonProperty("relayed")]
		[Column("relayed", IsTag = true)]
		public int Relayed { get; set; } = default!;

		[JsonProperty("row_id")]
		[Column("row_id", IsTag = true)]
		public int RowId { get; set; } = default!;

		[JsonProperty("section_id")]
		[Column("section_id", IsTag = true)]
		public string SectionId { get; set; } = default!;

		[JsonProperty("secure")]
		[Column("secure", IsTag = true)]
		public int Secure { get; set; } = default!;

		[JsonProperty("selected")]
		[Column("selected", IsTag = true)]
		public int Selected { get; set; } = default!;

		[JsonProperty("session_id")]
		[Column("session_id", IsTag = true)]
		public string SessionId { get; set; } = default!;

		[JsonProperty("session_key")]
		[Column("session_key", IsTag = true)]
		public string SessionKey { get; set; } = default!;

		[JsonProperty("sort_title")]
		[Column("sort_title", IsTag = true)]
		public string SortTitle { get; set; } = default!;

		[JsonProperty("state")]
		[Column("state", IsTag = true)]
		public string State { get; set; } = default!;

		[JsonProperty("stream_aspect_ratio")]
		[Column("stream_aspect_ratio", IsTag = true)]
		public string StreamAspectRatio { get; set; } = default!;

		[JsonProperty("stream_audio_bitrate")]
		[Column("stream_audio_bitrate", IsTag = true)]
		public string StreamAudioBitrate { get; set; } = default!;

		[JsonProperty("stream_audio_bitrate_mode")]
		[Column("stream_audio_bitrate_mode", IsTag = true)]
		public string StreamAudioBitrateMode { get; set; } = default!;

		[JsonProperty("stream_audio_channel_layout")]
		[Column("stream_audio_channel_layout", IsTag = true)]
		public string StreamAudioChannelLayout { get; set; } = default!;

		[JsonProperty("stream_audio_channels")]
		[Column("stream_audio_channels", IsTag = true)]
		public string StreamAudioChannels { get; set; } = default!;

		[JsonProperty("stream_audio_codec")]
		[Column("stream_audio_codec", IsTag = true)]
		public string StreamAudioCodec { get; set; } = default!;

		[JsonProperty("stream_audio_decision")]
		[Column("stream_audio_decision", IsTag = true)]
		public string StreamAudioDecision { get; set; } = default!;

		[JsonProperty("stream_audio_language")]
		[Column("stream_audio_language", IsTag = true)]
		public string StreamAudioLanguage { get; set; } = default!;

		[JsonProperty("stream_audio_language_code")]
		[Column("stream_audio_language_code", IsTag = true)]
		public string StreamAudioLanguageCode { get; set; } = default!;

		[JsonProperty("stream_audio_sample_rate")]
		[Column("stream_audio_sample_rate", IsTag = true)]
		public string StreamAudioSampleRate { get; set; } = default!;

		[JsonProperty("stream_bitrate")]
		[Column("stream_bitrate", IsTag = true)]
		public string StreamBitrate { get; set; } = default!;

		[JsonProperty("stream_container")]
		[Column("stream_container", IsTag = true)]
		public string StreamContainer { get; set; } = default!;

		[JsonProperty("stream_container_decision")]
		[Column("stream_container_decision", IsTag = true)]
		public string StreamContainerDecision { get; set; } = default!;

		[JsonProperty("stream_duration")]
		[Column("stream_duration", IsTag = true)]
		public string StreamDuration { get; set; } = default!;

		[JsonProperty("stream_subtitle_codec")]
		[Column("stream_subtitle_codec", IsTag = true)]
		public string StreamSubtitleCodec { get; set; } = default!;

		[JsonProperty("stream_subtitle_container")]
		[Column("stream_subtitle_container", IsTag = true)]
		public string StreamSubtitleContainer { get; set; } = default!;

		[JsonProperty("stream_subtitle_decision")]
		[Column("stream_subtitle_decision", IsTag = true)]
		public string StreamSubtitleDecision { get; set; } = default!;

		[JsonProperty("stream_subtitle_forced")]
		[Column("stream_subtitle_forced", IsTag = true)]
		public int StreamSubtitleForced { get; set; } = default!;

		[JsonProperty("stream_subtitle_format")]
		[Column("stream_subtitle_format", IsTag = true)]
		public string StreamSubtitleFormat { get; set; } = default!;

		[JsonProperty("stream_subtitle_language")]
		[Column("stream_subtitle_language", IsTag = true)]
		public string StreamSubtitleLanguage { get; set; } = default!;

		[JsonProperty("stream_subtitle_language_code")]
		[Column("stream_subtitle_language_code", IsTag = true)]
		public string StreamSubtitleLanguageCode { get; set; } = default!;

		[JsonProperty("stream_subtitle_location")]
		[Column("stream_subtitle_location", IsTag = true)]
		public string StreamSubtitleLocation { get; set; } = default!;

		[JsonProperty("stream_subtitle_transient")]
		[Column("stream_subtitle_transient", IsTag = true)]
		public int StreamSubtitleTransient { get; set; } = default!;

		[JsonProperty("stream_video_bit_depth")]
		[Column("stream_video_bit_depth", IsTag = true)]
		public string StreamVideoBitDepth { get; set; } = default!;

		[JsonProperty("stream_video_bitrate")]
		[Column("stream_video_bitrate", IsTag = true)]
		public string StreamVideoBitrate { get; set; } = default!;

		[JsonProperty("stream_video_chroma_subsampling")]
		[Column("stream_video_chroma_subsampling", IsTag = true)]
		public string StreamVideoChromaSubsampling { get; set; } = default!;

		[JsonProperty("stream_video_codec")]
		[Column("stream_video_codec", IsTag = true)]
		public string StreamVideoCodec { get; set; } = default!;

		[JsonProperty("stream_video_codec_level")]
		[Column("stream_video_codec_level", IsTag = true)]
		public string StreamVideoCodecLevel { get; set; } = default!;

		[JsonProperty("stream_video_color_primaries")]
		[Column("stream_video_color_primaries", IsTag = true)]
		public string StreamVideoColorPrimaries { get; set; } = default!;

		[JsonProperty("stream_video_color_range")]
		[Column("stream_video_color_range", IsTag = true)]
		public string StreamVideoColorRange { get; set; } = default!;

		[JsonProperty("stream_video_color_space")]
		[Column("stream_video_color_space", IsTag = true)]
		public string StreamVideoColorSpace { get; set; } = default!;

		[JsonProperty("stream_video_color_trc")]
		[Column("stream_video_color_trc", IsTag = true)]
		public string StreamVideoColorTrc { get; set; } = default!;

		[JsonProperty("stream_video_decision")]
		[Column("stream_video_decision", IsTag = true)]
		public string StreamVideoDecision { get; set; } = default!;

		[JsonProperty("stream_video_dynamic_range")]
		[Column("stream_video_dynamic_range", IsTag = true)]
		public string StreamVideoDynamicRange { get; set; } = default!;

		[JsonProperty("stream_video_framerate")]
		[Column("stream_video_framerate", IsTag = true)]
		public string StreamVideoFramerate { get; set; } = default!;

		[JsonProperty("stream_video_height")]
		[Column("stream_video_height", IsTag = true)]
		public string StreamVideoHeight { get; set; } = default!;

		[JsonProperty("stream_video_language")]
		[Column("stream_video_language", IsTag = true)]
		public string StreamVideoLanguage { get; set; } = default!;

		[JsonProperty("stream_video_language_code")]
		[Column("stream_video_language_code", IsTag = true)]
		public string StreamVideoLanguageCode { get; set; } = default!;

		[JsonProperty("stream_video_ref_frames")]
		[Column("stream_video_ref_frames", IsTag = true)]
		public string StreamVideoRefFrames { get; set; } = default!;

		[JsonProperty("stream_video_resolution")]
		[Column("stream_video_resolution", IsTag = true)]
		public string StreamVideoResolution { get; set; } = default!;

		[JsonProperty("stream_video_scan_type")]
		[Column("stream_video_scan_type", IsTag = true)]
		public string StreamVideoScanType { get; set; } = default!;

		[JsonProperty("stream_video_width")]
		[Column("stream_video_width", IsTag = true)]
		public string StreamVideoWidth { get; set; } = default!;

		[JsonProperty("studio")]
		[Column("studio", IsTag = true)]
		public string Studio { get; set; } = default!;

		[JsonProperty("subtitle_codec")]
		[Column("subtitle_codec", IsTag = true)]
		public string SubtitleCodec { get; set; } = default!;

		[JsonProperty("subtitle_container")]
		[Column("subtitle_container", IsTag = true)]
		public string SubtitleContainer { get; set; } = default!;

		[JsonProperty("subtitle_decision")]
		[Column("subtitle_decision", IsTag = true)]
		public string SubtitleDecision { get; set; } = default!;

		[JsonProperty("subtitle_forced")]
		[Column("subtitle_forced", IsTag = true)]
		public int SubtitleForced { get; set; } = default!;

		[JsonProperty("subtitle_format")]
		[Column("subtitle_format", IsTag = true)]
		public string SubtitleFormat { get; set; } = default!;

		[JsonProperty("subtitle_language")]
		[Column("subtitle_language", IsTag = true)]
		public string SubtitleLanguage { get; set; } = default!;

		[JsonProperty("subtitle_language_code")]
		[Column("subtitle_language_code", IsTag = true)]
		public string SubtitleLanguageCode { get; set; } = default!;

		[JsonProperty("subtitle_location")]
		[Column("subtitle_location", IsTag = true)]
		public string SubtitleLocation { get; set; } = default!;

		[JsonProperty("subtitles")]
		[Column("subtitles", IsTag = true)]
		public int Subtitles { get; set; } = default!;

		[JsonProperty("synced_version")]
		[Column("synced_version", IsTag = true)]
		public int SyncedVersion { get; set; } = default!;

		[JsonProperty("synced_version_profile")]
		[Column("synced_version_profile", IsTag = true)]
		public string SyncedVersionProfile { get; set; } = default!;

		[JsonProperty("throttled")]
		[Column("throttled", IsTag = true)]
		public string Throttled { get; set; } = default!;

		[JsonProperty("title")]
		[Column("title", IsTag = true)]
		public string Title { get; set; } = default!;

		[JsonProperty("transcode_audio_channels")]
		[Column("transcode_audio_channels", IsTag = true)]
		public string TranscodeAudioChannels { get; set; } = default!;

		[JsonProperty("transcode_audio_codec")]
		[Column("transcode_audio_codec", IsTag = true)]
		public string TranscodeAudioCodec { get; set; } = default!;

		[JsonProperty("transcode_container")]
		[Column("transcode_container", IsTag = true)]
		public string TranscodeContainer { get; set; } = default!;

		[JsonProperty("transcode_decision")]
		[Column("transcode_decision", IsTag = true)]
		public string TranscodeDecision { get; set; } = default!;

		[JsonProperty("transcode_height")]
		[Column("transcode_height", IsTag = true)]
		public string TranscodeHeight { get; set; } = default!;

		[JsonProperty("transcode_hw_decode")]
		[Column("transcode_hw_decode", IsTag = true)]
		public string TranscodeHwDecode { get; set; } = default!;

		[JsonProperty("transcode_hw_decode_title")]
		[Column("transcode_hw_decode_title", IsTag = true)]
		public string TranscodeHwDecodeTitle { get; set; } = default!;

		[JsonProperty("transcode_hw_decoding")]
		[Column("transcode_hw_decoding", IsTag = true)]
		public int TranscodeHwDecoding { get; set; } = default!;

		[JsonProperty("transcode_hw_encode")]
		[Column("transcode_hw_encode", IsTag = true)]
		public string TranscodeHwEncode { get; set; } = default!;

		[JsonProperty("transcode_hw_encode_title")]
		[Column("transcode_hw_encode_title", IsTag = true)]
		public string TranscodeHwEncodeTitle { get; set; } = default!;

		[JsonProperty("transcode_hw_encoding")]
		[Column("transcode_hw_encoding", IsTag = true)]
		public int TranscodeHwEncoding { get; set; } = default!;

		[JsonProperty("transcode_hw_full_pipeline")]
		[Column("transcode_hw_full_pipeline", IsTag = true)]
		public int TranscodeHwFullPipeline { get; set; } = default!;

		[JsonProperty("transcode_hw_requested")]
		[Column("transcode_hw_requested", IsTag = true)]
		public int TranscodeHwRequested { get; set; } = default!;

		[JsonProperty("transcode_key")]
		[Column("transcode_key", IsTag = true)]
		public string TranscodeKey { get; set; } = default!;

		[JsonProperty("transcode_max_offset_available")]
		[Column("transcode_max_offset_available", IsTag = true)]
		public int TranscodeMaxOffsetAvailable { get; set; } = default!;

		[JsonProperty("transcode_min_offset_available")]
		[Column("transcode_min_offset_available", IsTag = true)]
		public int TranscodeMinOffsetAvailable { get; set; } = default!;

		[JsonProperty("transcode_progress")]
		[Column("transcode_progress", IsTag = true)]
		public int TranscodeProgress { get; set; } = default!;

		[JsonProperty("transcode_protocol")]
		[Column("transcode_protocol", IsTag = true)]
		public string TranscodeProtocol { get; set; } = default!;

		[JsonProperty("transcode_speed")]
		[Column("transcode_speed", IsTag = true)]
		public string TranscodeSpeed { get; set; } = default!;

		[JsonProperty("transcode_throttled")]
		[Column("transcode_throttled", IsTag = true)]
		public int TranscodeThrottled { get; set; } = default!;

		[JsonProperty("transcode_video_codec")]
		[Column("transcode_video_codec", IsTag = true)]
		public string TranscodeVideoCodec { get; set; } = default!;

		[JsonProperty("transcode_width")]
		[Column("transcode_width", IsTag = true)]
		public string TranscodeWidth { get; set; } = default!;

		[JsonProperty("type")]
		[Column("type", IsTag = true)]
		public string Type { get; set; } = default!;

		[JsonProperty("updated_at")]
		[Column("updated_at", IsTag = true)]
		public string UpdatedAt { get; set; } = default!;

		[JsonProperty("user")]
		[Column("user", IsTag = true)]
		public string User { get; set; } = default!;

		[JsonProperty("user_id")]
		[Column("user_id", IsTag = true)]
		public int UserId { get; set; } = default!;

		[JsonProperty("user_rating")]
		[Column("user_rating", IsTag = true)]
		public string UserRating { get; set; } = default!;

		[JsonProperty("username")]
		[Column("username", IsTag = true)]
		public string Username { get; set; } = default!;

		[JsonProperty("video_bit_depth")]
		[Column("video_bit_depth", IsTag = true)]
		public string VideoBitDepth { get; set; } = default!;

		[JsonProperty("video_bitrate")]
		[Column("video_bitrate", IsTag = true)]
		public string VideoBitrate { get; set; } = default!;

		[JsonProperty("video_chroma_subsampling")]
		[Column("video_chroma_subsampling", IsTag = true)]
		public string VideoChromaSubsampling { get; set; } = default!;

		[JsonProperty("video_codec")]
		[Column("video_codec", IsTag = true)]
		public string VideoCodec { get; set; } = default!;

		[JsonProperty("video_codec_level")]
		[Column("video_codec_level", IsTag = true)]
		public string VideoCodecLevel { get; set; } = default!;

		[JsonProperty("video_color_primaries")]
		[Column("video_color_primaries", IsTag = true)]
		public string VideoColorPrimaries { get; set; } = default!;

		[JsonProperty("video_color_range")]
		[Column("video_color_range", IsTag = true)]
		public string VideoColorRange { get; set; } = default!;

		[JsonProperty("video_color_space")]
		[Column("video_color_space", IsTag = true)]
		public string VideoColorSpace { get; set; } = default!;

		[JsonProperty("video_color_trc")]
		[Column("video_color_trc", IsTag = true)]
		public string VideoColorTrc { get; set; } = default!;

		[JsonProperty("video_decision")]
		[Column("video_decision", IsTag = true)]
		public string VideoDecision { get; set; } = default!;

		[JsonProperty("video_dynamic_range")]
		[Column("video_dynamic_range", IsTag = true)]
		public string VideoDynamicRange { get; set; } = default!;

		[JsonProperty("video_frame_rate")]
		[Column("video_frame_rate", IsTag = true)]
		public string VideoFrameRate { get; set; } = default!;

		[JsonProperty("video_framerate")]
		[Column("video_framerate", IsTag = true)]
		public string VideoFramerate { get; set; } = default!;

		[JsonProperty("video_full_resolution")]
		[Column("video_full_resolution", IsTag = true)]
		public string VideoFullResolution { get; set; } = default!;

		[JsonProperty("video_height")]
		[Column("video_height", IsTag = true)]
		public string VideoHeight { get; set; } = default!;

		[JsonProperty("video_language")]
		[Column("video_language", IsTag = true)]
		public string VideoLanguage { get; set; } = default!;

		[JsonProperty("video_language_code")]
		[Column("video_language_code", IsTag = true)]
		public string VideoLanguageCode { get; set; } = default!;

		[JsonProperty("video_profile")]
		[Column("video_profile", IsTag = true)]
		public string VideoProfile { get; set; } = default!;

		[JsonProperty("video_ref_frames")]
		[Column("video_ref_frames", IsTag = true)]
		public string VideoRefFrames { get; set; } = default!;

		[JsonProperty("video_resolution")]
		[Column("video_resolution", IsTag = true)]
		public string VideoResolution { get; set; } = default!;

		[JsonProperty("video_scan_type")]
		[Column("video_scan_type", IsTag = true)]
		public string VideoScanType { get; set; } = default!;

		[JsonProperty("video_width")]
		[Column("video_width", IsTag = true)]
		public string VideoWidth { get; set; } = default!;

		[JsonProperty("view_offset")]
		[Column("view_offset", IsTag = true)]
		public string ViewOffset { get; set; } = default!;

		[JsonProperty("width")]
		[Column("width", IsTag = true)]
		public string Width { get; set; } = default!;

		[JsonProperty("year")]
		[Column("year", IsTag = true)]
		public string Year { get; set; } = default!;

        [Column("value")]
        public string Value => User;
    }
}